$.sidebarMenu = function (menu) {
	var animationSpeed = 300;

	$(menu).on("click", "li a", function (e) {
		var $this = $(this);
		var checkElement = $this.next();

		if (checkElement.is(".treeview-menu") && checkElement.is(":visible")) {
			checkElement.slideUp(animationSpeed, function () {
				checkElement.removeClass("menu-open");
			});
			checkElement.parent("li").removeClass("active");
		}

		//If the menu is not visible
		else if (
			checkElement.is(".treeview-menu") &&
			!checkElement.is(":visible")
		) {
			//Get the parent menu
			var parent = $this.parents("ul").first();
			//Close all open menus within the parent
			var ul = parent.find("ul:visible").slideUp(animationSpeed);
			//Remove the menu-open class from the parent
			ul.removeClass("menu-open");
			//Get the parent li
			var parent_li = $this.parent("li");

			//Open the target menu and add the menu-open class
			checkElement.slideDown(animationSpeed, function () {
				//Add the class active to the parent li
				checkElement.addClass("menu-open");
				parent.find("li.active").removeClass("active");
				parent_li.addClass("active");
				$("li").removeClass("current-page");
			});
		}
		//if this isn't a link, prevent the page from being redirected
		if (checkElement.is(".treeview-menu")) {
			e.preventDefault();
		}
	});
};
$.sidebarMenu($(".sidebar-menu"));

// Custom Sidebar JS
jQuery(function ($) {
	//toggle sidebar
	$("#toggle-sidebar").on("click", function () {
		console.log($(this));
		$(".page-wrapper").toggleClass("toggled");
		if($(".page-wrapper").hasClass('toggled')) {
			$(".toggle-sidebar #toggle-icon-btn").removeClass("bi-chevron-left").addClass("bi-chevron-right");

		} else {
			$(".toggle-sidebar #toggle-icon-btn").removeClass("bi-chevron-right").addClass("bi-chevron-left");
		}

	});

	// Pin sidebar on click
	$("#pin-sidebar").on("click", function () {
		if ($(".page-wrapper").hasClass("pinned")) {
			// unpin sidebar when hovered
			$(".page-wrapper").removeClass("pinned");
			$("#sidebar").unbind("hover");
			$(".pin-sidebar #icon-btn").removeClass("bi-chevron-right").addClass("bi-chevron-left");
		} else {
			$(".page-wrapper").addClass("pinned");
			$(".pin-sidebar #icon-btn").removeClass("bi-chevron-left").addClass("bi-chevron-right");

			$("#sidebar").hover(
				function () {
					console.log("mouseenter");
					$(".page-wrapper").addClass("sidebar-hovered");
				},
				function () {
					console.log("mouseout");
					$(".page-wrapper").removeClass("sidebar-hovered");
				}
			);
		}
	});

	// Pinned sidebar
	$(function () {
		$(".page-wrapper").hasClass("pinned");
		$("#sidebar").hover(
			function () {
				console.log("mouseenter");
				$(".page-wrapper").addClass("sidebar-hovered");
			},
			function () {
				console.log("mouseout");
				$(".page-wrapper").removeClass("sidebar-hovered");
			}
		);
	});

	// Toggle sidebar overlay
	$("#overlay").on("click", function () {
		$(".page-wrapper").toggleClass("toggled");
	});

	// Added by Srinu
	$(function () {
		// When the window is resized,
		$(window).resize(function () {
			// When the width and height meet your specific requirements or lower
			if ($(window).width() <= 768) {
				$(".page-wrapper").removeClass("pinned");
				
			}
		});
		// When the window is resized,
		$(window).resize(function () {
			// When the width and height meet your specific requirements or lower
			if ($(window).width() >= 768) {
				$(".page-wrapper").removeClass("toggled");
				
			}
		});
	});
});

/***********
Bootstrap JS 
***********/

// Tooltip
var tooltipTriggerList = [].slice.call(
	document.querySelectorAll('[data-bs-toggle="tooltip"]')
);
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
	return new bootstrap.Tooltip(tooltipTriggerEl);
});

// Popover
var popoverTriggerList = [].slice.call(
	document.querySelectorAll('[data-bs-toggle="popover"]')
);
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
	return new bootstrap.Popover(popoverTriggerEl);
});

var showSuccess = function (htmlMessage, type) {
	var body = $('.message');
	body.empty();
	var html = `<div class="fade show d-flex align-items-center  alert alert-${type}" id="top-message">
		${htmlMessage}
	</div>`;
	body.append(html).hide()
	.fadeIn(1000);
	setTimeout(()=>{
		$(".alert").fadeOut(1000, function() { $(this).remove(); });
	},4000);
}

function myFunction() {
	let isLogout = confirm("Are you sure you want to log out?");
	if(isLogout) {
		window.location.href="/login.html";
	}
}

	$(document).on("change","#themeselect", function () {
		var target = $('head link#target');

		if(this.value==1) {
			target.attr("href", "assets/css/theme/default.css");
		} else if(this.value==2) {
			target.attr("href", "assets/css/theme/white-grey.css");

		} else if(this.value==3) {
			target.attr("href", "assets/css/theme/black-grey.css");

		}
		else if(this.value==4) {
			target.attr("href", "assets/css/theme/black-blue.css");

		}
		else if(this.value==5) {
			target.attr("href", "assets/css/theme/white-red.css");

		}

		localStorage.setItem("currenttheme",target.attr("href"));
	})

	$( document ).ready(function() {
		let theme = localStorage.getItem("currenttheme");
		if(theme !== null) {
			$('head link#target').attr("href", theme);
		}
    });
 
	
	





