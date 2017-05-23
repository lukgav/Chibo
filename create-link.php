<?php
//WOW NICE MEME
namespace chibo;
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <link rel="stylesheet" href="css/table.css">
    <meta charset="UTF-8">
    <title>create a new recipe-ingredients link</title>
    <link rel="icon" href="assets/icon.ico" type="image/x-icon">
</head>
<body>
<h1>Add a new recipe:</h1>
<h3><a href="index.html">Go home.</a></h3>
<br><hr>
<?php
require "db_accessor.php";

$mydb = new db_accessor();
$ret = $mydb->selectFirstUnlinkedRecipe();
//set up table
$ing_result = $mydb->getIngredients();
echo '<table class="tg"><tr><th class="tg-title" colspan="2">';

//text in title bar
echo " result(s)." . '</th></tr>'; //$rows .

//echo the table and headings:
?>
<tr>
<td class="tg-heading">Recipe ID:</td>
<td class="tg-heading">Recipe Name:</td>

<?php

//while there are results to process, echo the stuff out of them:

$row = $ret->fetchArray(SQLITE3_ASSOC);
    //row setup stuff
    echo '<tr>';
    echo '<td class="tg-yw4l">' . $row['recipe id'] . "</td>";
    echo '<td class="tg-yw4l">' . $row['recipe name'] . "</td></tr>";
echo "</table><br>";

//do some array magic here
//fill a PHP array with the recipe array results
$ingredients = [];

//iterate through the ing_result array until no more ingredients:
while($ingredients[] = $ing_result->fetchArray(SQLITE3_ASSOC))
{ //do nothing, just do this until it returns false
}   //we now have $ingredients[i] of [id, name & desc]

//foreach ($ingredients as $val) {
//    echo $val['ingredient id'] . "<br>";
//    echo $val['ingredient name'] . "<br><br>";
//}

$mydb->close();
$js_array = json_encode($ingredients);
//echo $js_array;
?>
<form id="myForm">
    <select id="ing-list">
        <option>Choose a number</option>
    </select>
    <select hidden="true" id="qty-modifier">
        <option>kg</option>
        <option>g</option>
        <option>cups</option>
        <option>ml</option>
        <option>l</option>
        <option>pc</option>
        <option>tbsp</option>
        <option>tsp</option>
    </select>
</form>
<!--WE HTML FAM-->
<script type="text/javascript">
    //WOW NOW WE JS
    <?php
        //WOW NOW WE PHP OUT HERE CALM TF DOWN
        //echo "var javascript_array = " . $js_array . "\n\r";
        $chunk1 = array_chunk($ingredients, 32);
        $iteration = 0;
        foreach ($chunk1 as $i) {
            echo 'var js_array_' . $iteration . " = " . json_encode($i) . ";\n\r";
            $iteration += 1;
        }

    ?>
    var javascript_array = new Array();
    javascript_array = javascript_array.concat(js_array_0);
    javascript_array = javascript_array.concat(js_array_1);
    javascript_array = javascript_array.concat(js_array_2);
    javascript_array = javascript_array.concat(js_array_3);
    javascript_array = javascript_array.concat(js_array_4);
    javascript_array = javascript_array.concat(js_array_5);
    javascript_array = javascript_array.concat(js_array_6);

    console.log(javascript_array);

    var select = document.getElementById("ing-list");
    document.write("<b>DON'T USE THIS ^^^^^^ IT'S A DEMO</b><br><br><br>");
    select.innerHTML = "";
    for (var i = 0; i < javascript_array.length; ++i) {
        var opt = javascript_array[i];
        if (opt["ingredient name"] == null) {
            continue;
        }
        var el = document.createElement("option");
        el.textContent = opt["ingredient name"];
        el.value = opt["ingredient id"];
        select.appendChild(el);
    }
    document.write(javascript_array.length.toString() + " recipes in DB.");
</script>
<br><br><br>
Number of ingredients to add to recipe:<input type="text" id="member" name="member" value=""><br />
<button id="btn" onclick="addinputFields()">Generate n ing-rec links</button>
<div id="container"/>

<script type="text/javascript">
    //js memes and dynamically allocated text-field dreams

    function addinputFields(){
        //<form action=\"add-links.php\" id=\"ingform\" method=\"post\">");
        var theform = document.forms['ingform'];


        //var theform = document.getElementById('ingform');
        var number = document.getElementById("member").value;
        var firstDD = document.getElementById('ing-list');
        var options = firstDD.innerHTML;
        var qtylist = document.getElementById('qty-modifier');
        var qtyoptions = qtylist.innerHTML;

        for (i=0;i<number;i++){
            var input = document.createElement("select");
            input.name = "ingredient" + i.toString();
            input.innerHTML = options;
            theform.appendChild(input);


            var input2 = document.createElement("input");
            input2.type = "text";
            input2.name = "qty-" + i.toString();
            input2.size = 4;
            input2.placeholder = "qty...";
            theform.appendChild(input2);

            var input3 = document.createElement("select");
            input3.name = "mod-" + i.toString();
            input3.innerHTML = qtyoptions;
            theform.appendChild(input3);

            theform.appendChild(document.createElement("br"));
        }

        var submit = document.createElement("input");
        submit.id = "submitButton";
        submit.type = "submit";
        submit.value = "insert " + number.toString() + " links into db.";
        theform.appendChild(submit);

        var recipeID = document.createElement("input");
        recipeID.type = "hidden"
        var ID = <?php
            echo $row['recipe id'];
            ?>;
        recipeID.name = "recipeID";
        recipeID.value = ID;
        theform.appendChild(recipeID);

        var fields = document.createElement("input");
        fields.type = "hidden";
        fields.name = "numLinks";
        fields.value = number;
        theform.appendChild(fields);

    }
</script>
<form action="add-links.php" method="post" id="ingform">
</form>
</body>
</html>