/*function PreviewImage() {
    var oFReader = new FileReader();
    console.log(document.getElementById("StudentPhoto").files);
    oFReader.readAsDataURL(document.getElementById("StudentPhoto").files[0]);

    oFReader.onload = function (oFREvent) {

        document.getElementById("PhotoPreview").src = oFREvent.target.result;
        //document.getElementById("PhotoPreview").setAttribute("width","100");
        //document.getElementById("PhotoPreview").setAttribute("height","100");
    };
};
*/
function PreviewImage(Name) {
    var oFReader = new FileReader();
    oFReader.readAsDataURL(document.getElementById(Name).files[0]);
    oFReader.onload = function (oFREvent) {
        document.getElementById(Name + "Preview").src = oFREvent.target.result;
    };
};
