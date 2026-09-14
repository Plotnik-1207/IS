<?php

interface Printable {
    public function toString(): string;
}

class Person implements Printable {
    public $name;
    public $birthDate;

    public function __construct($name, $birthDate) {
        $this->name = $name;
        $this->birthDate = $birthDate;
    }

    public function toString(): string {
        return $this->name . " | " . $this->birthDate . "\n";
    }
}

class Cost implements Printable {
    public $govCost;
    public $marketCost;

    public function __construct($govCost, $marketCost) {
        $this->govCost = $govCost;
        $this->marketCost = $marketCost;
    }

    public function toString(): string {
        return "gov: " . $this->govCost . " | " . "market: " . $this->marketCost . "\n";
    }
}

class Doc implements Printable {
    public $owner;
    public $date;
    public $cost;

    public function __construct($ownerName, $birthDate, $date, $govCost, $marketCost) {
        $this->owner = new Person($ownerName, $birthDate);
        $this->date = $date;
        $this->cost = new Cost($govCost, $marketCost);
    }

    public function toString(): string {
        return $this->owner->toString() . " | ". $this->date . " | " . $this->cost->toString() . "\n";
    }
}

class PrintableList {
    private array $items = [];

    public function add(Printable $item): void {
        $this->items[] = $item;
    }

    public function toStringAll(): string {
        $result = "";
        
        foreach ($this->items as $item) {
            $result = $result . $item->toString();
        }

        return $result;
    }
}

function parse($str) {
    $a = explode(' ', $str);

    $marketCost = array_pop($a);
    $govCost = array_pop($a);
    $date = array_pop($a);
    $birthDate = array_pop($a);

    $ownerName = trim(implode(' ', $a), '"');

    return new Doc($ownerName, $birthDate, $date, $govCost, $marketCost);
}

function main() {
    $list = new PrintableList();

    while (true) {
        $str = readline();

        if ($str == "")
            break;

        $list->add(parse($str));
    }

    echo $list->toStringAll();
}

main();