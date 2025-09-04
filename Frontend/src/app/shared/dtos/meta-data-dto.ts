export class MetaDataDto {
    id: number = 0; // Provide a default value for 'id'
    storeName: string = '';
    address: string = '';
    street: string = '';
    city: string = '';
    state: string = '';
    zip: string = '';
    country: string = '';
    duration: string = ''; // Assuming you handle TimeSpan conversion on the client side
    distance: number = 0;
    dateTime: Date = new Date(); // Provide a default date (you can adjust this as needed)
    pointsEarned: number = 0;
    fare: number = 0.0;
    promotion: number = 0.0;
    boost: number = 0.0;
    tip: number = 0.0;
    yourEarnings: number = 0.0;
  }

  // currently not using this file
  