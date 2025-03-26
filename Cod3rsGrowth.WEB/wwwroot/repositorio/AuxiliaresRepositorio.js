sap.ui.define([
    './RepositorioBase'
], (RepositorioBase) => {
	"use strict";

    const CONTROLLER_NAME = "Auxiliares";

	return {
		obterEnumeradores: function() {
			return RepositorioBase.get(CONTROLLER_NAME);
		}
	};
});

