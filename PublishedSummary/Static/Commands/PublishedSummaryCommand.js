/**
 * Creates an anguilla command using a wrapper shorthand.
 *
 * Note the ${PluginName} will get replaced by the actual plugin name.
 */
Alchemy.command("${PluginName}", "PublishedSummary", {

    /**
     * If an init function is created, this will be called from the command's constructor when a command instance
     * is created.
     */
    init: function () {
        console.log("Init Method");
    },

    /**
     * Whether or not the command is enabled for the user (will usually have extensions displayed but disabled).
     * @returns {boolean}
     */
    isEnabled: function (selection) {
        console.log("isEnabled Method");
        return this.isAvailable(selection);
    },

    /**
     * Whether or not the command is available to the user.
     * @returns {boolean}
     */
    isAvailable: function (selection) {
        console.log("isAvailable Method");
        console.log("Selection Count: " + selection.getCount());
       // alert(selection.getCount());
        if (selection.getCount() == 1) {
            var itemType = $models.getItemType(selection.getItem(0))

            //alert("Item Type:" + itemType + "#Value:" + $const.ItemType.STRUCTUREGROUP + "#" + $const.ItemType.CATEGORYANDKEYWORDS);

            console.log("Item Type Selected: " + itemType)
            if (itemType == $const.ItemType.FOLDER ||
                itemType == $const.ItemType.STRUCTURE_GROUP ||
                itemType == $const.ItemType.PUBLICATION ||
                itemType == $const.ItemType.CATMAN) {
                //alert(itemType);
                return true;
            }
            
        }
        return false;
    },

    /**
     * Executes your command. You can use _execute or execute as the property name.
     */
    execute: function (selection) {
        var url = "${ViewsUrl}PublishedSummary.aspx?tcm=" + selection.getItems()[0];

        var onPopupClose = function () {
            $evt.removeEventHandler(this.properties.popupInstance, "unload", this.getDelegate(this.properties.popupCloseHandler));
            this.properties.popupInstance = null;
            this.properties.popupCloseHandler = null;
        }

        var popup = this.properties.popupInstance;
        //var args = { popupType: Tridion.Controls.Popup.Type.MODAL_IFRAME, items: selection.getItems() };
        //var args = { items: selection.getItems()[0] };
        if (popup) {
            popup.focus();
        }
        else {
            popup = $popup.create(url, "menubar=no,location=no,resizable=no,scrollbars=yes,status=no,width=1340,height=580", null).open();

            /*this.properties.popupInstance = popup;
            this.properties.popupCloseHandler = onPopupClose;
            $evt.addEventHandler(popup, "unload", this.getDelegate(onPopupClose));
            $evt.addEventHandler(popup, "load", this.getDelegate(this.onLoad));

            popup.open();*/
        }
       
    },
    onLoad: function(selection)
    {
        
    }
});