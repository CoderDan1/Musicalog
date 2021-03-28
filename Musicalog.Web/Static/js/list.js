(function () {

    function editClicked(e) {
        e.preventDefault();
        e.stopPropagation();
        window.location = '/albums/details/' + e.currentTarget.dataset.id;
    }

    function addAlbumClicked(e) {
        e.preventDefault();
        e.stopPropagation();
        window.location = '/albums/create';
    }

    document.addEventListener("DOMContentLoaded", function () {
        document.querySelectorAll(".edit").forEach(function (button) {
            button.addEventListener("click", editClicked);
        });

        document.getElementById("addAlbum").addEventListener("click", addAlbumClicked);
    });

})();