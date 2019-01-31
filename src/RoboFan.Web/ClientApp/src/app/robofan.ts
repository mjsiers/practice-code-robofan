export class RoboFan {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  city: string;
  state: string;
  birthDate: Date;
  age: number;
  imageUrl: string;
  teamName: string;
  teamImageUrl: string;
  posTeams: string[] = [];
  negTeams: string[] = [];

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}
