var GLOBAL = {};
GLOBAL.DotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
};
(function () {
    let serializeEvent = function (e) {
        if (e) {
            return {
                key: e.key,
                code: e.keyCode.toString(),
                location: e.location,
                repeat: e.repeat,
                ctrlKey: e.ctrlKey,
                shiftKey: e.shiftKey,
                altKey: e.altKey,
                metaKey: e.metaKey,
                type: e.type
            };
        }
    };


    window.addEventListener("keydown", function (e) {
        console.log(serializeEvent(e));
        GLOBAL.DotNetReference.invokeMethodAsync('KeyDown', serializeEvent(e));
    });
})();