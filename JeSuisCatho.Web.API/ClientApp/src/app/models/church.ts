export interface KeyValuePair {
  id: number;
  name: string;
}

export interface Details {
  name: string;
  fatherIncharge: string;
  addressLine: string;
  mailBox: string;
  website: string;
 
}

export interface Church {
  id: number;
  archDiocese: KeyValuePair;
  diocese: KeyValuePair;
  deanery: KeyValuePair;
  county: KeyValuePair;
  division: KeyValuePair;
 // isInvited: boolean;
  details: Details;
  
}
export interface SaveChurch {
  id: number;
  archDioceseId: number;
  dioceseId: number;
  divisionId: number;
  deaneryId: number;
  countyId: number;

  details: Details;
}
