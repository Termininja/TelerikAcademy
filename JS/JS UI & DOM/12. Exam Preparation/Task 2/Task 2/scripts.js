$.fn.gallery = function (columns) {
    var $this = this;
    var COLUMNS = 4;                    // default value for the columns
    var selectedImage = null;

    var $prevImage = $this.find('#previous-image');
    var $currImage = $this.find('#current-image');
    var $nextImage = $this.find('#next-image');

    //Finds the number of all allImages
    var galleryList = $this.find('.gallery-list');
    var allImages = parseInt(galleryList.find('img').length);

    columns = columns || COLUMNS;
    $this.addClass('gallery');
    $this.find('.selected').hide();

    setGalleryWidth();

    //Click event for image from the gallery
    $this.on('click', '.image-container', function () {
        if ((' ' + galleryList.attr('class') + ' ').indexOf(' blurred ') === -1) {
            //Finds the number of the clicked image
            selectedImage = parseInt($(this).find('img').attr('data-info'));

            SetAllImageSrc(selectedImage);
            $this.find('.selected').show();
            galleryList.addClass('blurred');
        }
    });

    //Click event for the previous image
    $prevImage.on('click', function () {
        selectedImage = (selectedImage > 1) ? selectedImage - 1 : allImages;
        SetAllImageSrc(selectedImage)
    });

    //Click event for the current image
    $currImage.on('click', function () {
        galleryList.removeClass('blurred');
        $this.find('.selected').hide();
    });

    //Click event for the next image
    $nextImage.on('click', function () {
        selectedImage = (selectedImage < allImages) ? selectedImage + 1 : 1;
        SetAllImageSrc(selectedImage)
    });

    return $(this);

    //Corrects the width of the gallery
    function setGalleryWidth() {
        //Finds the width of the images
        var imageWidthValue = $this.find('.image-container').css('width').replace('px', '');

        //Calculates and sets the width of the gallery
        var galleryWidth = columns * (+imageWidthValue + 10);
        $this.first().css('width', galleryWidth + 'px');
    }

    //Correct the source of displayed images
    function SetAllImageSrc(number) {
        //Sets the previous image
        $prevImage.attr('src', 'imgs/' + ((number <= 1) ? allImages : number - 1) + '.jpg')

        //Sets the current image 
        $currImage.attr('src', 'imgs/' + number + '.jpg')

        //Sets the next image 
        $nextImage.attr('src', 'imgs/' + ((number >= allImages) ? 1 : number + 1) + '.jpg')
    }
};