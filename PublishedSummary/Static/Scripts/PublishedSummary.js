
Type.registerNamespace("Alchemy.Plugins.PublishedSummary.Views");

Alchemy.Plugins.PublishedSummary.Views.PublishedSummary = function PublishedSummary() {
    Tridion.OO.enableInterface(this, "Alchemy.Plugins.PublishedSummary.Views.PublishedSummary");
    this.addInterface("Tridion.Cme.View");
};

Alchemy.Plugins.PublishedSummary.Views.PublishedSummary.prototype.initialize = function PublishedSummary$initialize() {
    this.callBase("Tridion.Cme.View", "initialize");
};

$display.registerView(Alchemy.Plugins.PublishedSummary.Views.PublishedSummary);

