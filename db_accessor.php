<?php
/**
 * Created by PhpStorm.
 * User: Fudge
 * Date: 15/05/2017
 * Time: 3:48 PM
 */

namespace chibo;


class db_accessor extends \SQLite3
{
    function __construct()
    {
        $this->open();
    }

    function open()
    {
        parent::open('/opt/sqlitedb/chibo_db.db3');
    }

    function close()
    {
        parent::close();
    }

    /**
     * "getters" of data.
     */

    function getAllRecipesAndIngredients ()
    {
        //gets an array of recipes
        $sql = <<<EOF
SELECT recipes.id AS "recipe ID", recipes.name AS "recipe name", recipes.tags AS "recipe tags", ingredients.id AS "ingredient id", ingredients.name AS "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID;
EOF;
        return parent::query($sql);
    }

    function getRecipePlusIngredients($id)
    {
        //returns details for a recipe with the ID, and associated ingredients
        $sql = <<<EOF
SELECT recipes.id AS "recipe ID", recipes.name AS "recipe name", recipes.tags AS "recipe tags", ingredients.id AS "ingredient id", ingredients.name AS "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID WHERE recipes.id = $id;
EOF;
        return parent::query($sql);

    }

    function getRecipes ()
    {
        //gets an array of recipes with their ingredients.
        $sql = <<<EOF
SELECT recipes.id AS "recipe ID", recipes.name AS "recipe name", recipes.tags AS "recipe tags", recipes.instructions AS "recipe instructions" from recipes;
EOF;
        return parent::query($sql);
    }

    function getRecipe ($idToGet)
    {
        //gets the details for an individual recipe, minus ingredients.
        $sql = <<<EOF
SELECT recipes.id AS "recipe id", recipes.name AS "recipe name", recipes.tags AS "recipe tags", recipes.instructions AS "recipe instructions" FROM recipes WHERE recipes.id = $idToGet; 
EOF;
        return parent::query($sql);
    }

    function getRecipesWithIng ($ing_id)
    {
        //returns a list of the recipes currently using the ingredient ID supplied.
        $sql = <<<EOF
SELECT recipes.id AS "recipe id", recipes.name AS "recipe name", ingredients.id AS "ingredient id", ingredients.name AS "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID WHERE ingredients.id  = $ing_id;
EOF;
        return parent::query($sql);

    }

    function getIngredients ()
    {
        /**
         * Gets all the ingredients stored in the database.
         */
        //gets all the ingredients stored in the DB
        $sql = <<<EOF
SELECT ingredients.id AS "ingredient id", ingredients.name AS "ingredient name", ingredients.description AS "ingredient description" from ingredients;
EOF;
        return parent::query($sql);
    }

    function getIngredientRecipeLinks ()
    {
        //view the relationships between recipes and ingredients
        $sql = <<<EOF
SELECT recipes.id AS "recipe id", recipes.name as "recipe name", ingredients.id as "ingredient id", ingredients.name as "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID;
EOF;
        return parent::query($sql);
    }


    /**
     * "adders"
     */


    function AddRecipe($name, $instructions, $tags)
    {
        //add a recipe with the three required things.
        $sql = <<<EOF
INSERT INTO recipes (name, instructions, tags) VALUES ('$name', '$instructions', '$tags');
EOF;
        return parent::query($sql);
    }

    function AddIngredient($name, $description)
    {
        //adds an ingredient with a generated ID, with supplied name and description
        $sql = <<<EOF
INSERT INTO ingredients (name, description) VALUES ('$name', '$description');
EOF;
        return parent::query($sql);
    }

    /**
     * "counters" for ingredients, recipes and links.
     */

    function CountRecipes()
    {
        //returns a count
        $sql = <<<EOF
SELECT COUNT(*) as count FROM recipes;
EOF;

        return parent::querySingle($sql);
    }

    function CountIngredients()
    {
        //returns a count of number of ingredients in the DB
        $sql = <<<EOF
SELECT COUNT(*) as count FROM ingredients;
EOF;
        return parent::querySingle($sql);

    }
    //TODO: add an overload for AddRecipe with image or some shit

    /**
     * "deleters" of ingredients, recipes and links.
     */

    function DeleteIngredient($IDtodelete)
    {
        //delete the ingredient of supplied id.
        if (!isset($IDtodelete)) {
            return null;
        } else {
            $sql = <<<EOF
DELETE FROM ingredients WHERE id = $IDtodelete;
EOF;
            return parent::querySingle($sql);

        }
    }

    function DeleteRecipe($idToDelete)
    {
        //delete the recipe of a supplied ID.
        if (!isset($idToDelete)) {
            return null;
        } else {
            $sql = <<<EOF
DELETE FROM recipes WHERE id = $idToDelete;
EOF;
            return parent::querySingle($sql);
        }
    }


}