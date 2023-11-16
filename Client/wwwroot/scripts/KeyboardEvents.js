var GLOBAL = {};
GLOBAL.DotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
};

(function () {
    let keyState = {};

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
        keyState[e.code] = {
            event: e,
            isKeyDown: true
        };
    });

    window.addEventListener("keyup", function (e) {
        keyState[e.code] = {
            event: e,
            isKeyDown: false
        };
    });

    setInterval(function () {
        for (const key in keyState) {
            if (keyState[key].isKeyDown) {
                console.log(serializeEvent(keyState[key].event, true));
                GLOBAL.DotNetReference.invokeMethodAsync('KeyDown', serializeEvent(keyState[key].event, true));
            }
        }
    }, 20); // keist skaiciu pagal update

})();