export interface KeyValuePair {
  id: number;
  name: string;
}

export interface Ambaco {
  title: string;
  subTitle: string;
  body: string;
  dateOfEvent: string;
  duration: string;
}

export interface Article {
  id: number;
  newsCategory: KeyValuePair;
  newsEvent: KeyValuePair;
  counties: KeyValuePair[];
  isInvited: boolean;
  ambaco: Ambaco;
  lastUpdate: string;
}
export interface SaveArticle {
  id: number;
  newsEventId: number;
  newsCategoryId: number;
  isInvited: boolean;
  locations: number[];
  ambaco: Ambaco;
}
