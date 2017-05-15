<?php
namespace  chibo;
   class MyDB extends \SQLite3
   {
       function __construct()
       {
           $this->open('/opt/sqlitedb/test.db');
       }
   }
   $db = new MyDB();
   if(!$db){
       echo $db->lastErrorMsg();
   } else {
       echo "Opened database successfully\n";
   }

$sql =<<<EOF
      SELECT * from COMPANY;
EOF;

$ret = $db->query($sql);
while($row = $ret->fetchArray(SQLITE3_ASSOC) ){
    echo "ID = ". $row['ID'] . "\n";
    echo "NAME = ". $row['NAME'] ."\n";
    echo "ADDRESS = ". $row['ADDRESS'] ."\n";
    echo "SALARY =  ".$row['SALARY'] ."\n\n";
}
echo "Operation done successfully<br \>";

echo "testing my db code! <br>";
include "db_accessor.php";
$myDBcode = new db_accessor();
if (!$myDBcode) {
    echo $myDBcode->lastErrorMsg();
} else {
    echo "created object!<br>";
}
$myDBcode->close();
echo "closed object!<br>";
echo "testing re-open:<br>";
$myDBcode->open();
if (!$myDBcode) {
    echo $myDBcode->lastErrorMsg();
} else {
    echo "created object!";
}
$myDBcode->close();
$db->close();