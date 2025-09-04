const PROXY_CONFIG = [
  {
    context: [
      "/api", // This will match any route starting with "/api"
      "/api/v1/trips", // Matches routes for the TripsController
      //EXAMINE ProxyRead.txt  < -- ---- -------
      //The wild card is not acceptable, mixed use of glob pattern and a string path, not both
      //"/api/v1/trips/*/customers", // Matches routes for the CustomersController
      "/api/authentication" // Matches routes for the AuthenticationController
    ],
    target: "http://localhost:5293", // The .NET server's address and port 5293.
    secure: false,
    logLevel: "debug" // Optional: enables logging of the proxy process
  }
];

module.exports = PROXY_CONFIG;
