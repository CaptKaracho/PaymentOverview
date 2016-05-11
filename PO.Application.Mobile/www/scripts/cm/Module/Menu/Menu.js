/// <reference path="../../Controler/CMControler.js" />

function clickMenu(menu) {


    if (menu === 1)
    { 
        //CMControler.navigateBaseComponent(JBaseComponents.components.content, JModules.modules.dashboard, true);
    }
    else if (menu === 2)
        CMControler.navigateBaseComponent(JBaseComponents.components.content, JModules.modules.process, true);

}

function logout() {
    $("#btnLogout").click();
}