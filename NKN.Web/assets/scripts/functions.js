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
			if ($(window).scrollTop() >= 300) {
				$('.js-header').addClass('sticky-header');
			}
			else {
				$('.js-header').removeClass('sticky-header');
			}
		},

		heroSlider: function () {
			$('.js-her-banner-slider').slick({
				infinite: true,
				slidesToShow: 1,
				slidesToScroll: 1,
				dots: true,
				arrows: false
			});
		}
	}
}());
