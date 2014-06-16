$.fn.tabs = function () {
    var $this = this;
    $this.addClass('tabs-container');
    $this.find('.tab-item-content').hide();

    $this.on('click', '.tab-item-title', function () {
        $this.find('.tab-item-content').hide();
        $this.find('.current').removeClass('current');
        $(this).next().show().parent().addClass('current');
    });

    return $(this);
};
