<?php
$con = mysqli_connect('localhost:3306', 'test', '', 'hospital_rnwa');

function getNonStandardizedAppointments($patientId){
         global $con;
         $query = "SELECT pat.Name as PatientName, phyAp.Name as AppointmentPhysicianName, ap.Start as StartTime, ap.End as EndTime, ap.ExaminationRoom as ExamRoom, phyPa.Name as PatientPhysician
                   FROM Appointment as ap 
                   JOIN Patient as pat ON ap.Patient = pat.SSN 
                   JOIN Physician as phyAp ON ap.Physician = phyAp.EmployeeID
                   JOIN Physician as phyPa ON pat.PCP = phyPa.EmployeeID
                   WHERE ap.Physician <> pat.PCP AND pat.SSN = '{$patientId}'";
         $result = mysqli_query($con, $query);
         $array = array();
         while ($row = mysqli_fetch_array($result)) {
            $array[] = "<td>" . $row["PatientName"] . "</td><td>" . $row["AppointmentPhysicianName"] . "</td><td>" . $row["StartTime"] . "</td><td>" . $row["EndTime"] . "</td><td>" . $row["ExamRoom"] . "</td><td>" . $row["PatientPhysician"] . "</td>";
        }
       
        return $array;
}

$params = array('uri' => 'http://test-uri/');
$server = new SoapServer(NULL, $params);
$server->addFunction('getNonStandardizedAppointments');
$server->handle();
?>