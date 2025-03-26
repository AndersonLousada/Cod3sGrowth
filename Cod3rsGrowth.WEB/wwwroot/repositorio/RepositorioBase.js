sap.ui.define([], () => {
	"use strict";

	return {

        obterQueryParameters: function(data){

            if(!data) return null

            let parametros = Object.entries(data);
            let  url = new URLSearchParams();
            const INDICE_PROPRIEDADE = 0;
            const INDICE_VALOR = 1;
            const VALOR_INICIAL = null;

            for (let i = 0; i < parametros.length; i++) {

                let propriedade = parametros[i][INDICE_PROPRIEDADE];
                let valor = parametros[i][INDICE_VALOR];

                if(valor != VALOR_INICIAL)
                    url.append(propriedade, valor);
            }

            return url.toString();
        },

        criarUrl: function(controller, filtros = null){
            let uri = `${window.location.origin}/api/${controller}`;

            let queryParameteres = this.obterQueryParameters(filtros);
            filtros ? uri += `?${queryParameteres}` : ""

            return uri
        },

        tratarExcecao: function(response){
            return response.json()
                .then(ex =>{
                    let error = new Error();
                    error.message = ex.Title;
                    error.stack = ex.Detail;
                    throw error;
                });
        },

		obterHeaders: function(method) {
			let myHeaders = new Headers();

            return {
                method: method,
                headers: myHeaders,
                mode: "cors",
                cache: "default",
            };
		},

        get: function(controller, filtros){
            const method = "GET";
            let headers = this.obterHeaders(method);
            let url = this.criarUrl(controller, filtros)
            return fetch(url, headers)
                .then((response) => {
                    if(response.ok)
                        return response.json();

                    return this.tratarExcecao(response);
                });
        }
	};
});

