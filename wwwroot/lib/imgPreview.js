    function PreviewImage() {
        var oFReader = new FileReader();
        oFReader.readAsDataURL(document.getElementById("Photo").files[0]);

        oFReader.onload = function (oFREvent) {

            document.getElementById("PhotoPreview").src = oFREvent.target.result;
           // document.getElementById("PhotoPreview").setAttribute("width","100");
         //   document.getElementById("PhotoPreview").setAttribute("height","100");
        };
    };
    function PreviewImage1() {
        var oFReader = new FileReader();
        oFReader.readAsDataURL(document.getElementById("StudentSignature").files[0]);

        oFReader.onload = function (oFREvent) {
            console.log(oFREvent);
            document.getElementById("StudentSignPreview").src = oFREvent.target.result;
            //document.getElementById("StudentSignPreview").setAttribute("width","100");
            //document.getElementById("StudentSignPreview").setAttribute("height","100");
        };
    };
    function PreviewImage2() {
        var oFReader = new FileReader();
        oFReader.readAsDataURL(document.getElementById("ParentSignature").files[0]);

        oFReader.onload = function (oFREvent) {
            document.getElementById("ParentSignPreview").src = oFREvent.target.result;
            //document.getElementById("ParentSignPreview").setAttribute("width","100");
            //document.getElementById("ParentSignPreview").setAttribute("height","50");
        };
    };
