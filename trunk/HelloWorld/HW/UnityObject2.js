var unityObject = {javaInstallDone: function(d, a, b) {
        var c = parseInt(d.substring(d.lastIndexOf("_") + 1), 10);
        if (!isNaN(c)) {
            setTimeout(function() {
                UnityObject2.instances[c].javaInstallDoneCallback(d, a, b)
            }, 10)
        }
    }};
var UnityObject2 = function(J) {
    var ac = [], i = window, Y = document, W = navigator, E = null, h = [], af = (document.location.protocol == "https:"), y = af ? "https://ssl-webplayer.unity3d.com/" : "http://webplayer.unity3d.com/", K = "_unity_triedjava", G = a(K), r = "_unity_triedclickonce", u = a(r), aa = false, B = [], O = false, w = null, f = null, P = null, l = [], T = null, q = [], V = false, U = "installed", L = "missing", b = "broken", v = "unsupported", C = "ready", z = "start", F = "error", Z = "first", A = "java", s = "clickonce", M = false, R = null, x = {pluginName: "Unity Player",pluginMimeType: "application/vnd.unity",baseDownloadUrl: y + "download_webplayer-3.x/",fullInstall: false,autoInstall: false,enableJava: true,enableJVMPreloading: false,enableClickOnce: true,enableUnityAnalytics: false,enableGoogleAnalytics: true,params: {},attributes: {},referrer: null,debugLevel: 0};
    x = jQuery.extend(true, x, J);
    if (x.referrer === "") {
        x.referrer = null
    }
    if (af) {
        x.enableUnityAnalytics = false
    }
    function a(ag) {
        var ah = new RegExp(escape(ag) + "=([^;]+)");
        if (ah.test(Y.cookie + ";")) {
            ah.exec(Y.cookie + ";");
            return RegExp.$1
        }
        return false
    }
    function e(ag, ah) {
        document.cookie = escape(ag) + "=" + escape(ah) + "; path=/"
    }
    function N(am) {
        var an = 0, ai, al, aj, ag, ah;
        if (am) {
            var ak = am.toLowerCase().match(/^(\d+)(?:\.(\d+)(?:\.(\d+)([dabfr])?(\d+)?)?)?$/);
            if (ak && ak[1]) {
                ai = ak[1];
                al = ak[2] ? ak[2] : 0;
                aj = ak[3] ? ak[3] : 0;
                ag = ak[4] ? ak[4] : "r";
                ah = ak[5] ? ak[5] : 0;
                an |= ((ai / 10) % 10) << 28;
                an |= (ai % 10) << 24;
                an |= (al % 10) << 20;
                an |= (aj % 10) << 16;
                an |= {d: 2 << 12,a: 4 << 12,b: 6 << 12,f: 8 << 12,r: 8 << 12}[ag];
                an |= ((ah / 100) % 10) << 8;
                an |= ((ah / 10) % 10) << 4;
                an |= (ah % 10)
            }
        }
        return an
    }
    function ae(al, ag) {
        var ai = Y.getElementsByTagName("body")[0];
        var ah = Y.createElement("object");
        var aj = 0;
        if (ai && ah) {
            ah.setAttribute("type", x.pluginMimeType);
            ah.style.visibility = "hidden";
            ai.appendChild(ah);
            var ak = 0;
            (function() {
                if (typeof ah.GetPluginVersion === "undefined") {
                    if (ak++ < 10) {
                        setTimeout(arguments.callee, 10)
                    } else {
                        ai.removeChild(ah);
                        al(null)
                    }
                } else {
                    var am = {};
                    if (ag) {
                        for (aj = 0; aj < ag.length; ++aj) {
                            am[ag[aj]] = ah.GetUnityVersion(ag[aj])
                        }
                    }
                    am.plugin = ah.GetPluginVersion();
                    ai.removeChild(ah);
                    al(am)
                }
            })()
        } else {
            al(null)
        }
    }
    function c() {
        var ag = "";
        if (t.x64) {
            ag = x.fullInstall ? "UnityWebPlayerFull64.exe" : "UnityWebPlayer64.exe"
        } else {
            ag = x.fullInstall ? "UnityWebPlayerFull.exe" : "UnityWebPlayer.exe"
        }
        if (x.referrer !== null) {
            ag += "?referrer=" + x.referrer
        }
        return ag
    }
    function ab() {
        var ag = "UnityPlayer.plugin.zip";
        if (x.referrer != null) {
            ag += "?referrer=" + x.referrer
        }
        return ag
    }
    function m() {
        return x.baseDownloadUrl + (t.win ? c() : ab())
    }
    function D(ai, ah, aj, ag) {
        if (ai === L) {
            M = true
        }
        if (jQuery.inArray(ai, q) === -1) {
            if (M) {
                j.send(ai, ah, aj, ag)
            }
            q.push(ai)
        }
        T = ai
    }
    var t = function() {
        var ai = W.userAgent, ak = W.platform;
        var am = /chrome/i.test(ai);
        var al = false;
        if (/msie/i.test(ai)) {
            al = parseFloat(ai.replace(/^.*msie ([0-9]+(\.[0-9]+)?).*$/i, "$1"))
        } else {
            if (/Trident/i.test(ai)) {
                al = parseFloat(ai.replace(/^.*rv:([0-9]+(\.[0-9]+)?).*$/i, "$1"))
            }
        }
        var an = {w3: typeof Y.getElementById != "undefined" && typeof Y.getElementsByTagName != "undefined" && typeof Y.createElement != "undefined",win: ak ? /win/i.test(ak) : /win/i.test(ai),mac: ak ? /mac/i.test(ak) : /mac/i.test(ai),ie: al,ff: /firefox/i.test(ai),op: /opera/i.test(ai),ch: am,ch_v: /chrome/i.test(ai) ? parseFloat(ai.replace(/^.*chrome\/(\d+(\.\d+)?).*$/i, "$1")) : false,sf: /safari/i.test(ai) && !am,wk: /webkit/i.test(ai) ? parseFloat(ai.replace(/^.*webkit\/(\d+(\.\d+)?).*$/i, "$1")) : false,x64: /win64/i.test(ai) && /x64/i.test(ai),moz: /mozilla/i.test(ai) ? parseFloat(ai.replace(/^.*mozilla\/([0-9]+(\.[0-9]+)?).*$/i, "$1")) : 0,mobile: /ipad/i.test(ak) || /iphone/i.test(ak) || /ipod/i.test(ak) || /android/i.test(ai) || /windows phone/i.test(ai)};
        an.clientBrand = an.ch ? "ch" : an.ff ? "ff" : an.sf ? "sf" : an.ie ? "ie" : an.op ? "op" : "??";
        an.clientPlatform = an.win ? "win" : an.mac ? "mac" : "???";
        var ao = Y.getElementsByTagName("script");
        for (var ag = 0; ag < ao.length; ++ag) {
            var aj = ao[ag].src.match(/^(.*)3\.0\/uo\/UnityObject2\.js$/i);
            if (aj) {
                x.baseDownloadUrl = aj[1];
                break
            }
        }
        function ah(ar, aq) {
            for (var at = 0; at < Math.max(ar.length, aq.length); ++at) {
                var ap = (at < ar.length) && ar[at] ? new Number(ar[at]) : 0;
                var au = (at < aq.length) && aq[at] ? new Number(aq[at]) : 0;
                if (ap < au) {
                    return -1
                }
                if (ap > au) {
                    return 1
                }
            }
            return 0
        }
        an.java = function() {
            if (W.javaEnabled()) {
                var at = (an.win && an.ff);
                var aw = false;
                if (at || aw) {
                    if (typeof W.mimeTypes != "undefined") {
                        var av = at ? [1, 6, 0, 12] : [1, 4, 2, 0];
                        for (var ar = 0; ar < W.mimeTypes.length; ++ar) {
                            if (W.mimeTypes[ar].enabledPlugin) {
                                var ap = W.mimeTypes[ar].type.match(/^application\/x-java-applet;(?:jpi-)?version=(\d+)(?:\.(\d+)(?:\.(\d+)(?:_(\d+))?)?)?$/);
                                if (ap != null) {
                                    if (ah(av, ap.slice(1)) <= 0) {
                                        return true
                                    }
                                }
                            }
                        }
                    }
                } else {
                    if (an.win && an.ie) {
                        if (typeof ActiveXObject != "undefined") {
                            function aq(ax) {
                                try {
                                    return new ActiveXObject("JavaWebStart.isInstalled." + ax + ".0") != null
                                } catch (ay) {
                                    return false
                                }
                            }
                            function au(ax) {
                                try {
                                    return new ActiveXObject("JavaPlugin.160_" + ax) != null
                                } catch (ay) {
                                    return false
                                }
                            }
                            if (aq("1.7.0")) {
                                return true
                            }
                            if (an.ie >= 8) {
                                if (aq("1.6.0")) {
                                    for (var ar = 12; ar <= 50; ++ar) {
                                        if (au(ar)) {
                                            if (an.ie == 9 && an.moz == 5 && ar < 24) {
                                                continue
                                            } else {
                                                return true
                                            }
                                        }
                                    }
                                    return false
                                }
                            } else {
                                return aq("1.6.0") || aq("1.5.0") || aq("1.4.2")
                            }
                        }
                    }
                }
            }
            return false
        }();
        an.co = function() {
            if (an.win && an.ie) {
                var ap = ai.match(/(\.NET CLR [0-9.]+)|(\.NET[0-9.]+)/g);
                if (ap != null) {
                    var at = [3, 5, 0];
                    for (var ar = 0; ar < ap.length; ++ar) {
                        var aq = ap[ar].match(/[0-9.]{2,}/g)[0].split(".");
                        if (ah(at, aq) <= 0) {
                            return true
                        }
                    }
                }
            }
            return false
        }();
        return an
    }();
    var j = function() {
        var ag = function() {
            var ao = new Date();
            var an = Date.UTC(ao.getUTCFullYear(), ao.getUTCMonth(), ao.getUTCDay(), ao.getUTCHours(), ao.getUTCMinutes(), ao.getUTCSeconds(), ao.getUTCMilliseconds());
            return an.toString(16) + am().toString(16)
        }();
        var ai = 0;
        var ah = window._gaq = (window._gaq || []);
        ak();
        function am() {
            return Math.floor(Math.random() * 2147483647)
        }
        function ak() {            
        }
        function aj(ar, ap, at, ao) {
            if (!x.enableUnityAnalytics) {
                if (ao) {
                    ao()
                }
                return
            }
            var an = "http://unityanalyticscapture.appspot.com/event?u=" + encodeURIComponent(ag) + "&s=" + encodeURIComponent(ai) + "&e=" + encodeURIComponent(ar);
            an += "&v=" + encodeURIComponent("b073107612b7");
            if (x.referrer !== null) {
                an += "?r=" + x.referrer
            }
            if (ap) {
                an += "&t=" + encodeURIComponent(ap)
            }
            if (at) {
                an += "&d=" + encodeURIComponent(at)
            }
            var aq = new Image();
            if (ao) {
                aq.onload = aq.onerror = ao
            }
            aq.src = parseURL(an)
        }
        function al(ap, an, aq, ay) {
            if (!x.enableGoogleAnalytics) {
                if (ay) {
                    ay()
                }
                return
            }
            var av = "/webplayer/install/" + ap;
            var aw = "?";
            if (an) {
                av += aw + "t=" + encodeURIComponent(an);
                aw = "&"
            }
            if (aq) {
                av += aw + "d=" + encodeURIComponent(aq);
                aw = "&"
            }
            if (ay) {
                ah.push(function() {
                    setTimeout(ay, 1000)
                })
            }
            var at = x.src;
            if (at.length > 40) {
                at = at.replace("http://", "");
                var ao = at.split("/");
                var ax = ao.shift();
                var ar = ao.pop();
                at = ax + "/../" + ar;
                while (at.length < 40 && ao.length > 0) {
                    var au = ao.pop();
                    if (at.length + au.length + 5 < 40) {
                        ar = au + "/" + ar
                    } else {
                        ar = "../" + ar
                    }
                    at = ax + "/../" + ar
                }
            }
            ah.push(["unity._setCustomVar", 2, "GameURL", at, 3]);
            ah.push(["unity._setCustomVar", 1, "UnityObjectVersion", "2", 3]);
            if (an) {
                ah.push(["unity._setCustomVar", 3, "installMethod", an, 3])
            }
            ah.push(["unity._trackPageview", av])
        }
        return {send: function(aq, ap, at, an) {
                if (x.enableUnityAnalytics || x.enableGoogleAnalytics) {
                    n("Analytics SEND", aq, ap, at, an)
                }
                ++ai;
                var ar = 2;
                var ao = function() {
                    if (0 == --ar) {
                        w = null;
                        window.location = parseURL(an)
                    }
                };
                if (at === null || at === undefined) {
                    at = ""
                }
                aj(aq, ap, at, an ? ao : null);
                al(aq, ap, at, an ? ao : null)
            }}
    }();
    function I(ai, aj, ak) {
        var ag, an, al, am, ah;
        if (t.win && t.ie) {
            an = "";
            for (ag in ai) {
                an += " " + ag + '="' + ai[ag] + '"'
            }
            al = "";
            for (ag in aj) {
                al += '<param name="' + ag + '" value="' + aj[ag] + '" />'
            }
            ak.outerHTML = "<object" + an + ">" + al + "</object>"
        } else {
            am = Y.createElement("object");
            for (ag in ai) {
                am.setAttribute(ag, ai[ag])
            }
            for (ag in aj) {
                ah = Y.createElement("param");
                ah.name = ag;
                ah.value = aj[ag];
                am.appendChild(ah)
            }
            ak.parentNode.replaceChild(am, ak)
        }
    }
    function o(ag) {
        if (typeof ag == "undefined") {
            return false
        }
        if (!ag.complete) {
            return false
        }
        if (typeof ag.naturalWidth != "undefined" && ag.naturalWidth == 0) {
            return false
        }
        return true
    }
    function H(aj) {
        var ah = false;
        for (var ai = 0; ai < l.length; ai++) {
            if (!l[ai]) {
                continue
            }
            var ag = Y.images[l[ai]];
            if (!o(ag)) {
                ah = true
            } else {
                l[ai] = null
            }
        }
        if (ah) {
            setTimeout(arguments.callee, 100)
        } else {
            setTimeout(function() {
                d(aj)
            }, 100)
        }
    }
    function d(aj) {
        var al = Y.getElementById(aj);
        if (!al) {
            al = Y.createElement("div");
            var ag = Y.body.lastChild;
            Y.body.insertBefore(al, ag.nextSibling)
        }
        var ak = x.baseDownloadUrl + "3.0/jws/";
        var ah = {id: aj,type: "application/x-java-applet",code: "JVMPreloader",width: 1,height: 1,name: "JVM Preloader"};
        var ai = {context: aj,codebase: ak,classloader_cache: false,scriptable: true,mayscript: true};
        I(ah, ai, al);
        jQuery("#" + aj).show()
    }
    function S(ah) {
        G = true;
        e(K, G);
        var aj = Y.getElementById(ah);
        var al = ah + "_applet_" + E;
        B[al] = {attributes: x.attributes,params: x.params,callback: x.callback,broken: x.broken};
        var an = B[al];
        var ak = {id: al,type: "application/x-java-applet",archive: x.baseDownloadUrl + "3.0/jws/UnityWebPlayer.jar",code: "UnityWebPlayer",width: 1,height: 1,name: "Unity Web Player"};
        if (t.win && t.ff) {
            ak.style = "visibility: hidden;"
        }
        var am = {context: al,jnlp_href: x.baseDownloadUrl + "3.0/jws/UnityWebPlayer.jnlp",classloader_cache: false,installer: m(),image: y + "installation/unitylogo.png",centerimage: true,boxborder: false,scriptable: true,mayscript: true};
        for (var ag in an.params) {
            if (ag == "src") {
                continue
            }
            if (an.params[ag] != Object.prototype[ag]) {
                am[ag] = an.params[ag];
                if (ag.toLowerCase() == "logoimage") {
                    am.image = an.params[ag]
                } else {
                    if (ag.toLowerCase() == "backgroundcolor") {
                        am.boxbgcolor = "#" + an.params[ag]
                    } else {
                        if (ag.toLowerCase() == "bordercolor") {
                            am.boxborder = true
                        } else {
                            if (ag.toLowerCase() == "textcolor") {
                                am.boxfgcolor = "#" + an.params[ag]
                            }
                        }
                    }
                }
            }
        }
        var ai = Y.createElement("div");
        aj.appendChild(ai);
        I(ak, am, ai);
        jQuery("#" + ah).show()
    }
    function X(ag) {
        setTimeout(function() {
            var ah = Y.getElementById(ag);
            if (ah) {
                ah.parentNode.removeChild(ah)
            }
        }, 0)
    }
    function g(ak) {
        var al = B[ak], aj = Y.getElementById(ak), ai;
        if (!aj) {
            return
        }
        aj.width = al.attributes.width || 600;
        aj.height = al.attributes.height || 450;
        var ah = aj.parentNode;
        var ag = ah.childNodes;
        for (var am = 0; am < ag.length; am++) {
            ai = ag[am];
            if (ai.nodeType == 1 && ai != aj) {
                ah.removeChild(ai)
            }
        }
    }
    function k(ai, ag, ah) {
        n("_javaInstallDoneCallback", ai, ag, ah);
        if (!ag) {
            D(F, A, ah)
        }
    }
    function ad() {
        ac.push(arguments);
        if (x.debugLevel > 0 && window.console && window.console.log) {
            console.log(Array.prototype.slice.call(arguments))
        }
    }
    function n() {
        ac.push(arguments);
        if (x.debugLevel > 1 && window.console && window.console.log) {
            console.log(Array.prototype.slice.call(arguments))
        }
    }
    function p(ag) {
        if (/^[-+]?[0-9]+$/.test(ag)) {
            ag += "px"
        }
        return ag
    }
    var Q = {getLogHistory: function() {
            return ac
        },getConfig: function() {
            return x
        },getPlatformInfo: function() {
            return t
        },initPlugin: function(ag, ah) {
            x.targetEl = ag;
            x.src = ah;
            n("ua:", t);
            this.detectUnity(this.handlePluginStatus)
        },detectUnity: function(at, ah) {
            var aq = this;
            var aj = L;
            var ak;
            W.plugins.refresh();
            if (t.clientBrand === "??" || t.clientPlatform === "???" || t.mobile) {
                aj = v
            } else {
                if (t.op && t.mac) {
                    aj = v;
                    ak = "OPERA-MAC"
                } else {
                    if (typeof W.plugins != "undefined" && W.plugins[x.pluginName] && typeof W.mimeTypes != "undefined" && W.mimeTypes[x.pluginMimeType] && W.mimeTypes[x.pluginMimeType].enabledPlugin) {
                        aj = U;
                        if (t.sf && /Mac OS X 10_6/.test(W.appVersion)) {
                            ae(function(au) {
                                if (!au || !au.plugin) {
                                    aj = b;
                                    ak = "OSX10.6-SFx64"
                                }
                                D(aj, P, ak);
                                at.call(aq, aj, au)
                            }, ah);
                            return
                        } else {
                            if (t.mac && t.ch) {
                                ae(function(au) {
                                    if (au && (N(au.plugin) <= N("2.6.1f3"))) {
                                        aj = b;
                                        ak = "OSX-CH-U<=2.6.1f3"
                                    }
                                    D(aj, P, ak);
                                    at.call(aq, aj, au)
                                }, ah);
                                return
                            } else {
                                if (ah) {
                                    ae(function(au) {
                                        D(aj, P, ak);
                                        at.call(aq, aj, au)
                                    }, ah);
                                    return
                                }
                            }
                        }
                    } else {
                        if (t.ie) {
                            var ai = false;
                            try {
                                if (ActiveXObject.prototype != null) {
                                    ai = true
                                }
                            } catch (am) {
                            }
                            if (!ai) {
                                aj = v;
                                ak = "ActiveXFailed"
                            } else {
                                aj = L;
                                try {
                                    var ar = new ActiveXObject("UnityWebPlayer.UnityWebPlayer.1");
                                    var ag = ar.GetPluginVersion();
                                    if (ah) {
                                        var an = {};
                                        for (var ap = 0; ap < ah.length; ++ap) {
                                            an[ah[ap]] = ar.GetUnityVersion(ah[ap])
                                        }
                                        an.plugin = ag
                                    }
                                    aj = U;
                                    if (ag == "2.5.0f5") {
                                        var ao = /Windows NT \d+\.\d+/.exec(W.userAgent);
                                        if (ao && ao.length > 0) {
                                            var al = parseFloat(ao[0].split(" ")[2]);
                                            if (al >= 6) {
                                                aj = b;
                                                ak = "WIN-U2.5.0f5"
                                            }
                                        }
                                    }
                                } catch (am) {
                                }
                            }
                        }
                    }
                }
            }
            D(aj, P, ak);
            at.call(aq, aj, an)
        },handlePluginStatus: function(ai, ag) {
            var ah = x.targetEl;
            var ak = jQuery(ah);
            switch (ai) {
                case U:
                    this.notifyProgress(ak);
                    this.embedPlugin(ak, x.callback);
                    break;
                case L:
                    this.notifyProgress(ak);
                    var aj = this;
                    var al = (x.debugLevel === 0) ? 1000 : 8000;
                    setTimeout(function() {
                        x.targetEl = ah;
                        aj.detectUnity(aj.handlePluginStatus)
                    }, al);
                    break;
                case b:
                    this.notifyProgress(ak);
                    break;
                case v:
                    this.notifyProgress(ak);
                    break
            }
        },getPluginURL: function() {
            var ag = "http://unity3d.com/webplayer/";
            if (t.win) {
                ag = x.baseDownloadUrl + c()
            } else {
                if (W.platform == "MacIntel") {
                    ag = x.baseDownloadUrl + (x.fullInstall ? "webplayer-i386.dmg" : "webplayer-mini.dmg");
                    if (x.referrer !== null) {
                        ag += "?referrer=" + x.referrer
                    }
                } else {
                    if (W.platform == "MacPPC") {
                        ag = x.baseDownloadUrl + (x.fullInstall ? "webplayer-ppc.dmg" : "webplayer-mini.dmg");
                        if (x.referrer !== null) {
                            ag += "?referrer=" + x.referrer
                        }
                    }
                }
            }
            return ag
        },getClickOnceURL: function() {
            return x.baseDownloadUrl + "3.0/co/UnityWebPlayer.application?installer=" + encodeURIComponent(x.baseDownloadUrl + c())
        },embedPlugin: function(aj, ar) {
            aj = jQuery(aj).empty();
            var ap = x.src;
            var ah = x.width || "100%";
            var am = x.height || "100%";
            var aq = this;
            if (t.win && t.ie) {
                var ai = "";
                for (var ag in x.attributes) {
                    if (x.attributes[ag] != Object.prototype[ag]) {
                        if (ag.toLowerCase() == "styleclass") {
                            ai += ' class="' + x.attributes[ag] + '"'
                        } else {
                            if (ag.toLowerCase() != "classid") {
                                ai += " " + ag + '="' + x.attributes[ag] + '"'
                            }
                        }
                    }
                }
                var al = "";
                al += '<param name="src" value="' + ap + '" />';
                al += '<param name="firstFrameCallback" value="UnityObject2.instances[' + E + '].firstFrameCallback();" />';
                for (var ag in x.params) {
                    if (x.params[ag] != Object.prototype[ag]) {
                        if (ag.toLowerCase() != "classid") {
                            al += '<param name="' + ag + '" value="' + x.params[ag] + '" />'
                        }
                    }
                }
                var ao = '<object classid="clsid:444785F1-DE89-4295-863A-D46C3A781394" style="display: block; width: ' + p(ah) + "; height: " + p(am) + ';"' + ai + ">" + al + "</object>";
                var an = jQuery(ao);
                aj.append(an);
                h.push(aj.attr("id"));
                R = an[0]
            } else {
                var ak = jQuery("<embed/>").attr({src: ap,type: x.pluginMimeType,width: ah,height: am,firstFrameCallback: "UnityObject2.instances[" + E + "].firstFrameCallback();"}).attr(x.attributes).attr(x.params).css({display: "block",width: p(ah),height: p(am)}).appendTo(aj);
                R = ak[0]
            }
            if (!t.sf || !t.mac) {
                setTimeout(function() {
                    R.focus()
                }, 100)
            }
            if (ar) {
                ar()
            }
        },getBestInstallMethod: function() {
            var ag = "Manual";
            if (t.x64) {
                return ag
            }
            if (x.enableJava && t.java && G === false) {
                ag = "JavaInstall"
            } else {
                if (x.enableClickOnce && t.co && u === false) {
                    ag = "ClickOnceIE"
                }
            }
            return ag
        },installPlugin: function(ah) {
            if (ah == null || ah == undefined) {
                ah = this.getBestInstallMethod()
            }
            var ag = null;
            switch (ah) {
                case "JavaInstall":
                    this.doJavaInstall(x.targetEl.id);
                    break;
                case "ClickOnceIE":
                    u = true;
                    e(r, u);
                    var ai = jQuery("<iframe src='" + this.getClickOnceURL() + "' style='display:none;' />");
                    jQuery(x.targetEl).append(ai);
                    break;
                default:
                case "Manual":
                    var ai = jQuery("<iframe src='" + this.getPluginURL() + "' style='display:none;' />");
                    jQuery(x.targetEl).append(ai);
                    break
            }
            P = ah;
            j.send(z, ah, null, null)
        },trigger: function(ah, ag) {
            if (ag) {
                n('trigger("' + ah + '")', ag)
            } else {
                n('trigger("' + ah + '")')
            }
            jQuery(document).trigger(ah, ag)
        },notifyProgress: function(ag) {
            if (typeof aa !== "undefined" && typeof aa === "function") {
                var ah = {ua: t,pluginStatus: T,bestMethod: null,lastType: P,targetEl: x.targetEl,unityObj: this};
                if (T === L) {
                    ah.bestMethod = this.getBestInstallMethod()
                }
                if (f !== T) {
                    f = T;
                    aa(ah)
                }
            }
        },observeProgress: function(ag) {
            aa = ag
        },firstFrameCallback: function() {
            n("*** firstFrameCallback (" + E + ") ***");
            T = Z;
            this.notifyProgress();
            if (M === true) {
                j.send(T, P)
            }
        },setPluginStatus: function(ai, ah, aj, ag) {
            D(ai, ah, aj, ag)
        },doJavaInstall: function(ag) {
            S(ag)
        },jvmPreloaded: function(ag) {
            X(ag)
        },appletStarted: function(ag) {
            g(ag)
        },javaInstallDoneCallback: function(ai, ag, ah) {
            k(ai, ag, ah)
        },getUnity: function() {
            return R
        }};
    E = UnityObject2.instances.length;
    UnityObject2.instances.push(Q);
    return Q
};
UnityObject2.instances = [];
