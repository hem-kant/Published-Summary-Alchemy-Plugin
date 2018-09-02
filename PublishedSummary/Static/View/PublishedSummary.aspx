<%@ Page Inherits="Tridion.Web.UI.Controls.TridionPage" %>

<html ng-app="alchemyApp">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css">
    <link rel="stylesheet" type="text/css" href="../css/published-summary.css">
    <link rel="stylesheet" type="text/css" href="../css/custom-control.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.2.26/angular.min.js"></script>

    <script>
        var queries = {};
        jQuery.each(document.location.search.substr(1).split('&'), function (c, q) {
            var i = q.split('=');
            queries[i[0].toString()] = i[1].toString();
        });

        alchemyApp = angular.module('alchemyApp', []);
        alchemyApp.controller('alchemyController', ['$scope', '$http', '$window', function ($scope, $http, $window) {

            $scope.publicationTargets = [];
            $scope.pages = true;
            $scope.components = true;
            $scope.categories = true;
            $scope.templates = true;

            $scope.fromDate = null;
            $scope.toDate = null;

            $scope.orderByField = 'title';
            $scope.reverseSort = false;


            $scope.Publications = {};
            $scope.Publications.selectionId = decodeURIComponent(queries.tcm.replace(/\+/g, '%20'));
            $scope.Publications.itemId = "";

            var itemID = "";
            var str = [];
            str = $scope.Publications.selectionId.split('-');
            if (str[2] != "1") {
                $scope.Publications.itemId = "tcm:0-" + str[0].substring(str[0].length - 2) + "-1";
            }
            else {
                $scope.Publications.itemId = $scope.Publications.selectionId;
            }

            $scope.executeQuery = function () {

                $http.get(document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetPublicationTarget").success(function (response) {
                    $scope.PublicationTarget = response;
                });

                $http({
                    url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetAllPublishedItems",
                    method: "POST",
                    data: "{'IDs':['" + $scope.Publications.selectionId + "']}"
                }).success(function (response) {
                    $scope.PublishedItems = response;
                });
                $http.get(document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetPublicationList").success(function (response) {
                    $scope.Publications.PublicationList = response;
                });

                $http({
                    url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetSummaryPanelData",
                    method: "POST",
                    data: "{'IDs':['" + $scope.Publications.itemId + "']}"
                }).success(function (response) {
                    $scope.PublishedSummaryPanelData = response;
                });
            }

            $scope.publish = function (itemID, target) {
                var confirmResult = confirm("Confirmation!\n The item with TCM URI - " + itemID + " will be published to " + target + " Publishing Target.\n Press OK to confirm.");
                if (confirmResult) {
                    jQuery("#progressDiv").show();
                    var temp = {};
                    temp.Id = itemID;
                    temp.Target = target;

                    $http({
                        url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/PublishItems",
                        method: "POST",
                        data: "{'IDs':[" + JSON.stringify(temp) + "]}"
                    }).success(function (response) {
                        jQuery("#progressDiv").hide();
                        alert("Send to publishing queue successfully!");
                    });
                }

            }

            $scope.unpublish = function (itemID, target) {
                var confirmResult = confirm("Confirmation!\n The item with TCM URI - " + itemID + " will be unpublished from " + target + " Publishing Target.\n Press OK to confirm.");
                if (confirmResult) {
                    jQuery("#progressDiv").show();
                    var temp = {};
                    temp.Id = itemID;
                    temp.Target = target;

                    $http({
                        url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/UnPublishItems",
                        method: "POST",
                        data: "{'IDs':[" + JSON.stringify(temp) + "]}"
                    }).success(function (response) {
                        jQuery("#progressDiv").hide();
                        alert("Send to publishing queue successfully!");
                    });
                }
            }

            $scope.onChange = function () {
                $http({
                    url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetAllPublishedItems",
                    method: "POST",
                    data: "{'IDs':['" + $scope.Publications.itemId + "']}"
                }).success(function (response) {
                    $scope.PublishedItems = response;
                });

                $http({
                    url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/GetSummaryPanelData",
                    method: "POST",
                    data: "{'IDs':['" + $scope.Publications.itemId + "']}"
                }).success(function (response) {
                    $scope.PublishedSummaryPanelData = response;
                });
            }


            $scope.filteredPublishedItems = function (items) {
                return function (item) {
                    for (var i in $scope.publicationTargets) {
                        if ($scope.publicationTargets[i]) {
                            if ($scope.PublicationTarget[i].title == item.publicationTarget) {
                                if (item.type == "Page" && $scope.pages) {
                                    return filteredDate(item);
                                }
                                if (item.type == "Component" && $scope.components) {
                                    return filteredDate(item);
                                }
                                if (item.type == "Category" && $scope.categories) {
                                    return filteredDate(item);
                                }
                                if (item.type == "ComponentTemplate" && $scope.templates) {
                                    return filteredDate(item);
                                }

                            }
                        }
                    }
                };
            };
            var filteredDate = function (item) {
                var returned = false;
                if ($scope.fromDate != null && $scope.toDate != null) {
                    if ($scope.toDate != "" && $scope.fromDate != "") {
                        returned = true;
                        var publishDate = new Date(item.publishedAt);
                        var fromDate = new Date($scope.fromDate);
                        var toDate = new Date($scope.toDate);
                        if (publishDate > fromDate && publishDate < toDate) {
                            return true;
                        }
                    }
                }
                if (!returned) {
                    return true;
                }
            };

            $scope.executeQuery();

            $scope.refresh = function () {
                if ($scope.PublicationTarget == null || $scope.PublishedItems == null || $scope.PublishedSummaryPanelData == null) {
                    $scope.executeQuery();
                }
            }
            $scope.refresh();
        }]);

        alchemyApp.directive("toggleClass", function () {
            return {
                link: function ($scope, element, attr) {
                    element.on("click", function () {
                        element.toggleClass("selected-row");
                    });
                }
            }
        });

        $(document).ready(function () {
            $("#btn_export").click(function () {
                var csvArray = [];
                var csv = "";
                var dom = $$(".row-eq-height div");
                for (var index = 0; index < dom.length; index++) {
                    if ((index + 1) % 7 != 0) {
                        csv += dom[index].innerText + ",";
                    }
                    else {
                        csvArray.push(csv.slice(0, -1));
                        csv = "";
                    }
                }
                csvArray.push(csv.slice(0, -1));

                console.log("csvArray JSON: " + JSON.stringify(csvArray));
                downloadJSON2CSV(csvArray);
            });


            $("#btn_delta").click(function () {
                alert("This feature will be released in version 2.0");
            });

            $("#btn_sync").click(function () {
                alert("This feature will be released in version 2.0");
            });



            function downloadJSON2CSV(objArray) {
                //var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;
                var array = objArray;
                console.log("Array Passed: " + array);
                var str = '';
                console.log("Array Length: " + array.length);
                for (var i = 0; i < array.length; i++) {
                    str += array[i] + '\r\n';
                }

                console.log("str: " + str);

                if (navigator.appName != 'Microsoft Internet Explorer') {
                    window.open('data:text/csv;charset=utf-8,' + escape(str));
                }
                else {
                    var popup = window.open('', 'csv', '');
                    popup.document.body.innerHTML = '<pre>' + str + '</pre>';
                }
            };

        });

        $(function () {

            $("#btn_unpublish_selected").click(function () {
                var unpublishParams = getSelectedItems();
                var confirmResult = confirm("Confirmation!\n" + unpublishParams.length + " items will be sent to the publishing queue for unpublishing.\n Press OK to confirm.");
                if (confirmResult) {
                    jQuery("#progressDiv").show();
                    var jsonParam = "{'IDs':" + JSON.stringify(unpublishParams) + "}";
                    console.log(jsonParam);
                    jQuery.ajax({
                        type: "POST",
                        url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/UnPublishItems",
                        data: jsonParam,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            jQuery("#progressDiv").hide();
                            alert("Send to publishing queue successfully for unpublishing!");
                        },
                        failure: function (response) {
                            jQuery("#progressDiv").hide();
                            alert(response.responseText);
                        },
                        error: function (response) {
                            jQuery("#progressDiv").hide();
                            alert(response.responseText);
                        }
                    });
                }
            });

            $("#btn_publish_selected").click(function () {
                var publishParams = getSelectedItems();

                var confirmResult = confirm("Confirmation!\n" + publishParams.length + " items will be sent to the publishing queue for publishing.\n Press OK to confirm.");
                if (confirmResult) {
                    jQuery("#progressDiv").show();
                    var jsonParam = "{'IDs':" + JSON.stringify(publishParams) + "}";
                    console.log(jsonParam);
                    jQuery.ajax({
                        type: "POST",
                        url: document.location.origin + "/Alchemy/Plugins/Published_Summary/api/Service/PublishItems",
                        data: jsonParam,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            jQuery("#progressDiv").hide();
                            alert("Send to publishing queue successfully for publishing!");
                        },
                        failure: function (response) {
                            jQuery("#progressDiv").hide();
                            alert(response.responseText);
                        },
                        error: function (response) {
                            jQuery("#progressDiv").hide();
                            alert(response.responseText);
                        }
                    });
                }
            });

            function getSelectedItems() {
                var dom = $$(".selected-row div");
                var params = [];
                for (var index = 0; index < dom.length; index = index + 7) {
                    var temp = {};
                    temp.Id = dom[index].innerText;
                    temp.Target = dom[index + 3].innerText
                    params.push(temp);
                }
                return params;
            }
        });

    </script>



</head>
<body>
    <div id="pub-summary" class="" ng-controller="alchemyController">

        <div class="col-sm-2 fixed">
            <img src="../img/content-bloom-logo-150x75.jpg" alt="www.contentbloom.com" />
            <hr />
            <!--<div id="clear-filters" class="row text-right clear-filter-link"><a href="#">Clear All Filters</a></div>-->
            <div id="publish-target-filters" class="filters">
                <h2>Publishing Target</h2>

                <label class="checkbox-container" ng-repeat="data in PublicationTarget">
                    <input type="checkbox" ng-checked="true" ng-model="publicationTargets[$index]" ng-init="publicationTargets[$index]=true" />{{data.title}}
                     <span class="checkmark"></span>
                </label>
            </div>

            <div id="item-type-filters" class="filters">
                <h2>Item Type</h2>

                <label class="checkbox-container">
                    Pages
				      <input type="checkbox" checked="checked" ng-model="pages">
                    <span class="checkmark"></span>
                </label>

                <label class="checkbox-container">
                    Components
				      <input type="checkbox" checked="checked" ng-model="components">
                    <span class="checkmark"></span>
                </label>

                <label class="checkbox-container">
                    Categories
				      <input type="checkbox" checked="checked" ng-model="categories">
                    <span class="checkmark"></span>
                </label>

                <label class="checkbox-container">
                    Templates
				      <input type="checkbox" checked="checked" ng-model="templates">
                    <span class="checkmark"></span>
                </label>
            </div>

            <div id="date-range-filters" class="filters">
                <h2>Date Range</h2>

                <label for="fromdate" class="padding-top-5">From:</label>
                <input type="date" name="fromdate" id="fromdate" ng-model="fromDate">

                <label for="todate" class="padding-top-5">To:</label>
                <input type="date" name="todate" id="todate" ng-model="toDate">
            </div>
        </div>
        <!-- Left Side Panel -->

        <div class="col-sm-9 flex-item">
            <div class="row">
                <div class="col-sm-3 top-left">
                    <div class="select">
                        <select name="publications" id="publications" ng-model="Publications.itemId" ng-options="publication.id as publication.title for publication in Publications.PublicationList" ng-change="onChange()">
                        </select>
                    </div>
                    <div>
                        <input type="text" placeholder="Search" ng-model="SearchText" class="textbox" />
                    </div>
                </div>

                <div class="col-sm-9 top-left">
                    <div class="summary-panel-header-grid">
                        <div class="row-summary-panel">
                            <div ng-repeat="data in PublishedSummaryPanelData">
                                <div class="summary-panel-heading col-sm-2">{{data.title}}</div>

                                <div class="summary-panel-details col-sm-4">
                                    <div>Total:<b>{{data.page + data.component  + data.category + data.componentTemplate }}</b></div>
                                    <div>Pages:<b>{{data.page}}</b></div>
                                    <div>Components:<b>{{data.component}}</b></div>
                                    <div>Categories:<b>{{data.category}}</b></div>
                                    <div>Templates:<b>{{data.componentTemplate}}</b></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Summary Panel and Publication Dropdown -->

                <div class="row">
                    <div class="col-sm-12 padding-left-5">
                        <hr>
                    </div>
                </div>
                <!-- Horizontal Row - Right Pane - Top -->
                <div id="progressDiv" class="progress-modal"></div>
                    
                <div class="summary-grid">
                    <div class="row-eq-height row-header align-middle">
                        <div class="col-xs-2" ng-click="orderByField='id'; reverseSort = !reverseSort">
                            ID <span ng-show="orderByField == 'id'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-2" ng-click="orderByField='title'; reverseSort = !reverseSort">
                            Title <span ng-show="orderByField == 'title'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-2" ng-click="orderByField='type'; reverseSort = !reverseSort">
                            Type <span ng-show="orderByField == 'type'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-1" ng-click="orderByField='publicationTarget'; reverseSort = !reverseSort">
                            Target <span ng-show="orderByField == 'publicationTarget'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-2" ng-click="orderByField='user'; reverseSort = !reverseSort">
                            By <span ng-show="orderByField == 'user'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-2" ng-click="orderByField='publishedAt'; reverseSort = !reverseSort">
                            Date <span ng-show="orderByField == 'publishedAt'"><span ng-show="!reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet"></span></span><span ng-show="reverseSort"><span class="sort-icon glyphicon glyphicon-sort-by-alphabet-alt"></span></span></span>
                        </div>
                        <div class="col-xs-1">Action</div>
                    </div>
                    <div class="row-eq-height" toggle-class ng-repeat="data in PublishedItems | filter:SearchText | filter:filteredPublishedItems(data) | orderBy:orderByField:reverseSort">

                        <div class="col-xs-2">{{data.id}}</div>
                        <div class="col-xs-2">{{data.title}}</div>
                        <div class="col-xs-2">{{data.type}}</div>
                        <div class="col-xs-1">{{data.publicationTarget}}</div>
                        <div class="col-xs-2">{{data.user}}</div>
                        <div class="col-xs-2">{{data.publishedAt | date:"dd MMM yyyy"}}</div>
                        <div class="col-xs-1">
                            <a href="javascript:void(0);" ng-click="publish(data.id, data.publicationTarget)" data-toggle="tooltip" title="Publish Item!">
                                <img class="action-icon publish-icon" src="#" /></a>
                            <a href="javascript:void(0);" ng-click="unpublish(data.id, data.publicationTarget)" data-toggle="tooltip" title="Unpublish Item!">
                                <img class="action-icon unpublish-icon" src="#" /></a>
                            <a href="{{data.openItem}}" data-toggle="tooltip" title="Open Item!" target="_blank">
                                <img class="action-icon open-icon" src="#" /></a>

                        </div>
                    </div>
                </div>
                <!-- Summary Grid -->

                <div class="col-sm-12 actions padding-left-5">
                    <button id="btn_delta" class="col-sm-2 button">Show Delta</button>
                    <button id="btn_sync" class="col-sm-3 button">Sync Publishing with Live</button>
                    <button id="btn_publish_selected" class="col-sm-2 button">Publish Selected</button>
                    <button id="btn_unpublish_selected" class="col-sm-2 button">Unpublish Selected</button>
                    <button id="btn_export" class="col-sm-2 button">Export in CSV</button>
                </div>
                <!-- CTA -->
                <div class="col-sm-12 copyright">&copy; Content Bloom, 2018 | v1.0.0.0 </div>

            </div>
            <!-- Right Side Panel -->
        </div>
    </div>
</body>
</html>
