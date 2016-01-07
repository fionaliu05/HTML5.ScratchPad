'use strict';
var GulpConfig = (function () {
    function gulpConfig() {
        //Got tired of scrolling through all the comments so removed them
        //Don't hurt me AC :-)
        //this.source = './src/';
        //this.sourceApp = this.source + 'app/';

        //this.tsOutputPath = this.source + '/js';
        //this.allJavaScript = [this.source + '/js/**/*.js'];
        //this.allTypeScript = this.sourceApp + '/**/*.ts';

        //this.typings = './typings/';
        //this.libraryTypeScriptDefinitions = './typings/**/*.ts';

        this.bowerDir = './bower_components';
        this.targetViewsDir = './Views/Home/Index.cshtml';
    }

    return gulpConfig;
})();
module.exports = GulpConfig;