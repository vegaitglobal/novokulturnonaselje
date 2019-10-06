var mobileView = $(window).width() < 768;
var mobileAndTabletView = $(window).width() < 1025;

var functions = (function() {
	return {
		languageSwitcher: function () {
			$('.js-selected-item').on('click', function () {
				if (!$(this).hasClass('open')) {
					$(this).addClass('open');
					$(this).next('.js-language-list').stop().slideDown();

					if (mobileAndTabletView) {
						$('.js-header-hamburger').removeClass('open');
						$('.js-nav').hide();
					}
				} else {
					$(this).removeClass('open');
					$(this).next('.js-language-list').stop().slideUp();
				}
			});
		},

		mobileNavInit: function () {
			$('.js-header-hamburger').on('click', function () {
				if (!$(this).hasClass('open')) {
					$(this).addClass('open');
					$('.js-nav').stop().slideDown();

					if (mobileAndTabletView) {
						$('.js-selected-item').removeClass('open');
						$('.js-language-list').hide();
					}
				} else {
					$(this).removeClass('open');
					$('.js-nav').stop().slideUp();
				}
			});
		},

		stickyHeader: function () {
			if ($(window).scrollTop() >= 500) {
				$('.js-header').addClass('header-sticky');
			}
			else {
				$('.js-header').removeClass('header-sticky');
			}
		},

		heroSlider: function () {
			if ($('.js-hero-banner-slider').length) {
				$('.js-hero-banner-slider').slick({
					infinite: true,
					slidesToShow: 1,
					slidesToScroll: 1,
					dots: true,
					arrows: false
				});
			}
		},

		contributorsSlider: function () {
			if ($('.js-contributors-slider').length) {
				$('.js-contributors-slider').slick({
					infinite: true,
					slidesToShow: 4,
					slidesToScroll: 4,
					dots: true,
					arrows: false
				});
			}
		},

		missionSlider: function () {
			if ($('.js-mission-slider').length) {
				$('.js-mission-slider').slick({
					infinite: true,
					slidesToShow: 4,
					slidesToScroll: 1,
					arrows: true,
					responsive: [
						{
							breakpoint: 768,
							settings: {
								slidesToShow: 1
							}
						}
					]
				});
			}
		},

		fourEqualHeight: function () {
			if ($('.js-four-highlighted-block').length) {
				if (!mobileView) {
					$('.js-four-highlighted-block').each(function () {
						helpers.equalHeight($(this).find('.image-holder'), 4);
					});
				} else {
					$('.js-four-highlighted-block').find('.image-holder').css('height', '');
				}
			}
		}
	}
}());

var helpers = (function() {
	return {
		equalHeight : function (arrayItems, count) {
			if (arrayItems !== undefined && arrayItems.length > 0) {
				arrayItems.height('');

				let maxH = 0;

				if (count) {
					let arrays = [];
					while (arrayItems.length > 0) {
						arrays.push(arrayItems.splice(0, count));
					}

					for (let i = 0; i < arrays.length; i += 1) {
						let data = arrays[i];
						maxH = 0;
						for (let j = 0; j < data.length; j += 1) {
							let currentH = $(data[j]).outerHeight(true);
							if (currentH > maxH) {
								maxH = currentH;
							}
						}

						for (let k = 0; k < data.length; k += 1) {
							$(data[k]).css('height', maxH);
						}
					}
				} else {
					arrayItems.each(function () {
						let currentH2 = $(this).outerHeight(true);
						if (currentH2 > maxH) {
							maxH = currentH2;
						}
					});

					arrayItems.css('height', maxH);
				}
			}
		}
	}
}());