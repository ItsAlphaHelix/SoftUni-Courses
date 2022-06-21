function createAssemblyLine() {
 
  return {
    hasClima(car) {
      car.temp = 21;
      car.tempSettings = 21;
        car.adjustTemp = () => {
        if (car.temp < car.tempSettings) {
          car.temp++;
        } else if (car.temp > car.tempSettings) {
          car.temp--;
        }
 
      };
    },
    hasAudio(car) {
      car.currentTrack = {'name': '', 'artist': ''};
      car.nowPlaying = function() {
        if (car.currentTrack !== null) {
          console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
        }
      };
    },
    hasParktronic(car) {
        car.checkDistance = (distance) => {
        if (distance < 0.1) {
          console.log('Beep! Beep! Beep!');
        } else if (distance >= 0.1 && distance < 0.25) {
          console.log('Beep! Beep!');
        } else if (distance >= 0.25 && distance < 0.5) {
          console.log('Beep!');
        } else {
          console.log('');
        }
      };
    }
  };
}
const assemblyLine = createAssemblyLine();

const car = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(car);
console.log(car.temp);
car.tempSettings = 18;
car.adjustTemp();
console.log(car.temp);