class CreditCardFactory {
    static getCreditCard(cardType) {
        let cardDetails = null;

        if (cardType === "MoneyBack") {
            cardDetails = new MoneyBack();
        } else if (cardType === "Titanium") {
            cardDetails = new Titanium();
        } else if (cardType === "Platinum") {
            cardDetails = new Platinum();
        }
        return cardDetails;
    }
}

class MoneyBack {
    getCardType() {
        return "MoneyBack";
    }

    getCreditLimit() {
        return 15000;
    }

    getAnnualCharge() {
        return 500;
    }
}

class Platinum {
    getCardType() {
        return "Platinum Plus";
    }

    getCreditLimit() {
        return 35000;
    }

    getAnnualCharge() {
        return 2000;
    }
}

class Titanium {
    getCardType() {
        return "Titanium Edge";
    }

    getCreditLimit() {
        return 25000;
    }

    getAnnualCharge() {
        return 1500;
    }
}

function main() {
    let cardDetails = CreditCardFactory.getCreditCard("Platinum");

    if (cardDetails !== null) {
        console.log("CardType : " + cardDetails.getCardType());
        console.log("CreditLimit : " + cardDetails.getCreditLimit());
        console.log("AnnualCharge : " + cardDetails.getAnnualCharge());
    } else {
        console.log("Invalid Card Type");
    }
}

main();
