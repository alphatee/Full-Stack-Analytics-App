// a model of my data that I want from the server for use for my service 
export interface TripInfoData {
  storeName: string;
  address: string;
  street: string;
  city: string;
  state: string;
  zip: string;
  country: string;
  duration: string; // Format: HH:MM:SS
  distance: number; // in miles
  dateTime: string; // ISO 8601 format
  pointsEarned: number;
  fare: number;
  promotion: number;
  boost: number;
  tip: number;
  yourEarnings: number;
}


// Optional: alias for arrays of trips
export type TripInfoList = TripInfoData[];