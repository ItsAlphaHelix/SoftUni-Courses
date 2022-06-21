function solve(drivingInKm, zone) {
    let typeOfSpeed;
    let restrictionSpeed;
    let isGreater = false;

    if (zone === 'residential') {
        restrictionSpeed = 20;

        if (drivingInKm > restrictionSpeed) {
            isGreater = true;
        }
        else {
            isGreater = false;
        }
    }
    else if (zone === 'city') {
        restrictionSpeed = 50;

        if (drivingInKm > restrictionSpeed) {
            isGreater = true;
        }
        else {
            isGreater = false;
        }
    }
    else if (zone === 'motorway') {
        restrictionSpeed = 130;

        if (drivingInKm > restrictionSpeed) {
            isGreater = true;
        }
        else {
            isGreater = false;
        }
    }
    else if (zone === 'interstate') {
        restrictionSpeed = 90;

        if (drivingInKm > restrictionSpeed) {
            isGreater = true;
        }
        else {
            isGreater = false;
        }
    }
    if (isGreater == true) {

        if (drivingInKm - restrictionSpeed <= 20) {
            typeOfSpeed = 'speeding';
        }
        else if (drivingInKm - restrictionSpeed <= 40) {
            typeOfSpeed = 'excessive speeding';
        }
        else {
            typeOfSpeed = 'reckless driving';
        }

        //You can and this way.
        // let result = drivingInKm - restrictionSpeed <= 20 ? typeOfSpeed = 'speeding'
        // : drivingInKm - restrictionSpeed <= 40 ? typeOfSpeed = 'excessive speeding'
        // : typeOfSpeed = 'reckless driving';
        
        console.log(`The speed is ${drivingInKm - restrictionSpeed} km/h faster than the allowed speed of ${restrictionSpeed} - ${typeOfSpeed}`);
    }
    else {
        console.log(`Driving ${drivingInKm} km/h in a ${restrictionSpeed} zone`)
    }
};
solve(200, 'motorway');