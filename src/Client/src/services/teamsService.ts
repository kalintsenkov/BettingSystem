const teamsService = {
  getOriginalLogo: (id: number) => {
    return 'http://localhost:5004/teams/' + id + '/originalLogo';
  },

  getThumbnailLogo: (id: number) => {
    return 'http://localhost:5004/teams/' + id + '/thumbnailLogo';
  }
};

export default teamsService;
