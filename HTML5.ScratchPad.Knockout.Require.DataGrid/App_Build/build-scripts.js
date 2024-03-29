﻿({
    appDir: "../Scripts",
    dir: "../Scripts-Build",
    baseUrl: "app",
    mainConfigFile: "../Scripts/main.js",
    paths: {
        main: "../main"
    },
    keepBuildDir: false,
    modules: [{
        name: "main",
        include: [
            // These JS files will be on EVERY page in the main.js file
            // So they should be the files we will almost always need everywhere
            "domReady",
            "jquery",
            "jqueryValidate",
            "jqueryValidateUnobtrusive",
            "bootstrap",
            "knockout",
            "knockoutMapping"
        ]
    },
    // These are page-specific bundles, usually named main-*
    {
        name: "CustomerViewModel",
        exclude: ["main"]
    }
    ],
    onBuildRead: function (moduleName, path, contents) {
        if (moduleName === "main") {
            return contents.replace("Scripts", "Scripts-Build");
        }
        return contents;
    }
})