export interface KeyValuePair {
  id: number;
  name: string;
}

export interface Pupil {

  firstName: string;
  lastName: string;
  favoriteColor: string;
  dateOfBirth: string;
  admissionNo: string;

}

export interface Guardian {

  id: number;
  firstName: string;
  otherName: string;
 



}


export interface Student {
  id: number;

  curriculum: KeyValuePair;
  curriculumClass: KeyValuePair;
  isActive: boolean;
  locations: KeyValuePair[];
  guardians: KeyValuePair[];
  pupil: Pupil;
  lastUpdate: string;

}

export interface SaveStudent {
  id: number;
  curriculumId: number;
  curriculumClassId: number;
 
  isActive: boolean;
  locations: number[];
  guardians: number[];
  pupil: Pupil;
 

}
