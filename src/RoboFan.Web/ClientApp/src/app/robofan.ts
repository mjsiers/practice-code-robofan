export class RoboFan {
  id: number;
  firstname: string;
  lastname: string;
  address: string;
  city: string;
  state: string;
  birthdate: Date;
  age: number;
  fanimageurl: string;
  teamname: string;
  teamimageurl: string;
  posteams: string[] = [];
  negteams: string[] = [];

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}
