<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <style>
        .table {
            margin-top: 20px
        }
    </style>
</head>
<body>
<div class="container-fluid">   
<?php
$name = $_GET["patientId"];
$params = array('location' => 'http://localhost/SOAP/PHP/src/server.php',
                'uri' => 'urn:urn://www.test-uri.com/',
                'trace' => 1);

$client = new SoapClient(null, $params);
$return = $client->__soapCall("getNonStandardizedAppointments", array($name));

echo '<table class="table">';
echo '<thead class="thead-dark">';
echo '<tr>';
echo '<th scope="col">Ime pacijent</th>';
echo '<th scope="col">Ime liječnika</th>';
echo '<th scope="col">Vrijeme početka sastanka</th>';
echo '<th scope="col">Vrijeme završetka sastanka</th>';
echo '<th scope="col">Soba</th>';
echo '<th scope="col">Liječnik primarne njege</th>';
echo '</tr>';
echo '</thead>';
echo '<tbody>';
foreach ($return as $row) {
    echo '<tr>';
    echo $row;
    echo '</tr>';
}
echo '</tbody>';
echo '</table>';
?>
</div>
</body>
</html>

