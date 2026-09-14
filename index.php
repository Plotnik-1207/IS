<?php

class person {
    public $name;
    public $birthDate;

    public function __construct($name, $birthDate) {
        $this->name = $name;
        $this->birthDate = $birthDate;
    }
}

class cost {
    public $govCost;
    public $marketCost;

    public function __construct($govCost, $marketCost) {
        $this->govCost = $govCost;
        $this->marketCost = $marketCost;    
    }
}

class doc {
    public $owner;
    public $date;
    public $cost;

    public function __construct($ownerName, $birthDate, $date, $govCost, $marketCost) {
        $this->owner = new person($ownerName, $birthDate);
        $this->date = $date;
        $this->cost = new cost($govCost, $marketCost);
    }
}

function parse($str) {
    $a = explode(' ', $str);

    $marketCost = array_pop($a);
    $govCost = array_pop($a);
    $date = array_pop($a);
    $birthDate = array_pop($a);

    $ownerName = trim(implode(' ', $a), '"');

    return new doc($ownerName, $birthDate, $date, $govCost, $marketCost);
}

function main() {
    $array = [];

    while (true) {
        $str = readline();

        if ($str == "")
            break;

        $array[] = parse($str);
    }
}

main();