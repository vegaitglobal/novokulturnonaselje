$(function () {

	functions.languageSwitcher();
	functions.mobileNavInit();
	functions.stickyHeader();
	functions.sliderInit();
	functions.simpleGalleryInit();
	functions.subscribe();
	functions.simpleVideoInit();
	functions.popupClose();

});

$(window).on('load', function() {

	functions.equalHeightInit();



});

$(window).resize(function(){

	functions.equalHeightInit();

});

$(window).on('scroll', function () {

	functions.stickyHeader();

});

