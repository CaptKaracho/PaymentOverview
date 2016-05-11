//JsonModel = jm
var JModules = (function () {

    var modules = {
        title: {
            name: 'title',
            filesCss: {
                name: 'title',
                path: 'scripts/cm/Module/Title/Title.css'
            },
            fileHtml: {
                name: 'title',
                path: 'scripts/cm/Module/Title/Title.html'
            },
            fileJs: {
                name: 'title',
                path: 'scripts/cm/Module/Title/Title.js'
            }
        },
        menu: {
            name: 'menu',
            filesCss: {
                name: 'menu',
                path: 'scripts/cm/Module/Menu/Menu.css'
            },
            fileHtml: {
                name: 'menu',
                path: 'scripts/cm/Module/Menu/Menu.html'
            },
            fileJs: {
                name: 'menu',
                path: 'scripts/cm/Module/Menu/Menu.js'
            }
        },
        process: {
            name: 'process',
            filesCss: {
                name: 'process',
                path: 'scripts/cm/Module/Process/Process.css'
            },
            fileHtml: {
                name: 'dashboard',
                path: 'scripts/cm/Module/Process/Process.html'
            },
            fileJs: {
                name: 'dashboard',
                path: 'scripts/cm/Module/Process/Process.js'
            }
        }
    }
    return {
        modules: modules
    }
})();