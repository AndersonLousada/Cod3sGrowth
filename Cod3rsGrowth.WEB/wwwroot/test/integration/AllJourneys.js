sap.ui.define([
	"sap/ui/test/Opa5",
	"./arrangements/Startup",
	"./pages/carros/JornadaLista",
], function (Opa5, Startup) {
	"use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "coders.growth.app.",
		autoWait: true
	});
});
