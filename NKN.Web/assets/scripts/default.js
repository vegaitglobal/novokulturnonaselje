$(function () {

	functions.languageSwitcher();
	functions.mobileNavInit();
	functions.stickyHeader();
	functions.subscribe();
	functions.simpleVideoInit();
	functions.popupClose();
	functions.simpleGalleryInit();
	functions.galleryVideoInit();
	sliders.sliderInit();
	sliders.projectSliderInit();
	sliders.gallerySimpleSliderInit();
	sliders.imageGallerySliderInit();
	sliders.imageGalleryDetailSliderInit();
	sliders.videoGallerySliderInit();

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

