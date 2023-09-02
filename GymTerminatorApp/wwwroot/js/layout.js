<script>
    $(document).ready(function () {
        // Manejar clics en los enlaces del menú
        $(".nav-link").on("click", function (e) {
            e.preventDefault(); // Evitar que se cargue la página completa

            // Obtener la URL del enlace
            var url = $(this).attr("href");

            // Cargar el contenido de la página de forma asincrónica
            $("#content-container").load(url);
        });
    });
</script>
