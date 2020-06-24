/// <reference path="jquery-3.4.1.min.js" />


<script src="~/Scripts/jquery-3.4.1.min.js"></script>
  
        $(document).ready(function() {
            $('.error').hide();
           $('#submit').click(function(){
                var name = $('#name').val();
               var email = $('#Email').val();

                if(name== ''){
            $('#name').next().show();
                   return false;
                 }
                 if(email== ''){
            $('#email').next().show();
                    return false;
                 }
                 if(IsEmail(email)==false){
            $('#invalid_email').show();
                     return false;
                 }
                 $.post("", $("#myform").serialize(),  function(response) {
            $('#myform').fadeOut('slow', function () {
                $('#correct').html(response);
                $('#correct').fadeIn('slow');
            });
                  });
                  return false;
               });
           });
           function IsEmail(email) {
             var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2, 4})+$/;
             if(!regex.test(email)) {
                return false;
             }else{
                return true;
             }
           }
     