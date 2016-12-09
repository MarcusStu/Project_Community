/// <reference path="angular.min.js" />

var app = angular.module("myApp", ["ngRoute"])
                 .config(function ($routeProvider) {

                     // Routes to specific urls and sends the request to a specific controller
                     $routeProvider
                        .when("/home", {
                            templateUrl: "/http/Home/home.html",
                            controller: "homeController"
                        })
                         .when("/forum", {
                             templateUrl: "/http/Forum/forum.html",
                             controller: "forumController"
                         })
                         // If the request does not match any of the above, it redirects to /home
                     .otherwise({
                         redirectTo: "/home"
                     })
                 })

.controller("homeController", function ($scope, $http) {
    $http.get("Home/Index")
    //.then(function (response) {
    //    $scope.persons = response.data;
    //    console.log(response.data);
    //})
})

.controller("forumController", function ($scope, $http) {
    $http.get("Home/Forum")
    //.then(function (response) {
    //    $scope.persons = response.data;
    //    console.log(response.data);
    //})
})








// Live Chat
// Change glyphicon to plus by default, when clicked change to minus
// Not working properly, clicking the + icon does not change it to minus
$(function () {
    //$("#plus_icon_chat").unbind('click');
    $("#plus_icon_chat").click(function (e) {
        $(this).toggleClass("glyphicon glyphicon-plus glyphicon glyphicon-minus");
    });
});
$(function () {
    //$("#chat_panel_click").unbind('click');
    $("#chat_panel_click").click(function (e) {
        $('#plus_icon_chat').toggleClass("glyphicon glyphicon-plus glyphicon glyphicon-minus");
    });
});

// Charcounter for live chat text box (to avoid overflow)
/**
 *
 * jquery.charcounter.js version 1.2
 * requires jQuery version 1.2 or higher
 * Copyright (c) 2007 Tom Deater (http://www.tomdeater.com)
 * Licensed under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 * 
 */
(function ($) {
    /**
	 * attaches a character counter to each textarea element in the jQuery object
	 * usage: $("#myTextArea").charCounter(max, settings);
	 */

    $.fn.charCounter = function (max, settings) {
        max = max || 100;
        settings = $.extend({
            container: "<span></span>",
            classname: "charcounter",
            format: "(%1 characters remaining)",
            pulse: true,
            delay: 0
        }, settings);
        var p, timeout;

        function count(el, container) {
            el = $(el);
            if (el.val().length > max) {
                el.val(el.val().substring(0, max));
                if (settings.pulse && !p) {
                    pulse(container, true);
                };
            };
            if (settings.delay > 0) {
                if (timeout) {
                    window.clearTimeout(timeout);
                }
                timeout = window.setTimeout(function () {
                    container.html(settings.format.replace(/%1/, (max - el.val().length)));
                }, settings.delay);
            } else {
                container.html(settings.format.replace(/%1/, (max - el.val().length)));
            }
        };

        function pulse(el, again) {
            if (p) {
                window.clearTimeout(p);
                p = null;
            };
            el.animate({ opacity: 0.1 }, 100, function () {
                $(this).animate({ opacity: 1.0 }, 100);
            });
            if (again) {
                p = window.setTimeout(function () { pulse(el) }, 200);
            };
        };

        return this.each(function () {
            var container;
            if (!settings.container.match(/^<.+>$/)) {
                // use existing element to hold counter message
                container = $(settings.container);
            } else {
                // append element to hold counter message (clean up old element first)
                $(this).next("." + settings.classname).remove();
                container = $(settings.container)
								.insertAfter(this)
								.addClass(settings.classname);
            }
            $(this)
				.unbind(".charCounter")
				.bind("keydown.charCounter", function () { count(this, container); })
				.bind("keypress.charCounter", function () { count(this, container); })
				.bind("keyup.charCounter", function () { count(this, container); })
				.bind("focus.charCounter", function () { count(this, container); })
				.bind("mouseover.charCounter", function () { count(this, container); })
				.bind("mouseout.charCounter", function () { count(this, container); })
				.bind("paste.charCounter", function () {
				    var me = this;
				    setTimeout(function () { count(me, container); }, 10);
				});
            if (this.addEventListener) {
                this.addEventListener('input', function () { count(this, container); }, false);
            };
            count(this, container);
        });
    };

})(jQuery);
$(function () {
    $(".counted").charCounter(320, { container: "#counter" });
});



