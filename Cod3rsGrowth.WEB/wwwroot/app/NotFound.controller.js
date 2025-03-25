sap.ui.define([
    "sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History"
 ], function (Controller, History) {
    "use strict";
    return Controller.extend("coders.growth.app.NotFound", {
        onInit: function () {},

        aoClicarEmVoltar: function() {
            const oHistory = History.getInstance();
            const sPreviousHash = oHistory.getPreviousHash();

            if (sPreviousHash !== undefined) {
                window.history.go(-1);
            } else {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo("lista", {}, true);
            }
        }
    });
 });