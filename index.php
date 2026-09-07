<?php
class doc {
    public $owner;
    public $date;
    public $cost;
}
function main() {
    $array = [];
    while(true){
        $Doc = new doc();
        $str = readline();
        if ($str == "")
            break;
        $a = explode(' ', $str);
        $Doc->date = array_pop($a);
        $Doc->cost = array_pop($a);
        $Doc->owner = trim(implode(' ', $a), '"');
        $array[] = $Doc;
    }

}
function m($array){
    $count = 0;
    foreach ($array as $i){
        if(explode('.', $i->date)[1] == "07"){
            $count++;
        }
    }
}
main();
$Doc = new doc();
echo "Введите строку\n";
$s = readline();
$a = explode(' ', $s);
$Doc->date = array_pop($a);
$Doc->cost = array_pop($a);
$Doc->owner = trim(implode(' ', $a), '"');
echo "Владелец: $Doc->owner\n";
echo "Дата постановки на учет: $Doc->date\n";
echo "Ориентировачная стоимость: $Doc->cost\n";