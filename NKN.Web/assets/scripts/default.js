$(function(){

	functions.languageSwitcher();
	functions.mobileNavInit();
	functions.stickyHeader();
	functions.heroSlider();
	functions.contributorsSlider();

});

$(window).on('load', function() {

	functions.fourEqualHeight();

});

$(window).on('scroll', function () {

	functions.stickyHeader();

});

$(window).resize(function(){

	functions.fourEqualHeight();

});