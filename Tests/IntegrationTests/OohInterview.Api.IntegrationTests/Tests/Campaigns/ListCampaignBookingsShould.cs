using System;
using System.Net.Http;
using System.Threading.Tasks;
using OohInterview.Api.Campaigns.Bookings;
using OohInterview.Api.IntegrationTests.Assertions;
using OohInterview.DAL.Builders;
using OohInterview.DAL.Pocos;
using Xunit;

namespace OohInterview.Api.IntegrationTests.Tests.Campaigns
{
    public class ListCampaignBookingsShould : BaseIntegrationTest
    {
        [Fact]
        public async Task ReturnA200Response()
        {
            var url = CreateUrl(GetEndpoint(Guid.NewGuid()));
            var response = await Client.GetAsync(url);
            response.AssertSuccessResponse();
        }

        [Fact]
        public async Task ReturnAllOfTheBookings()
        {
            var campaign = new CampaignBuilder().BuildAndAddToContext(DataContext);
            SetupBookingForCampaign(campaign.Id);
            SetupBookingForCampaign(campaign.Id);

            var bookings = await GetCampaignBookings(campaign.Id);

            Assert.Equal(2, bookings.Items.Count);
        }

        [Fact]
        public async Task NotReturnUnrelatedBookings()
        {
            var expectedCampaign = new CampaignBuilder().BuildAndAddToContext(DataContext);
            var otherCampaign = new CampaignBuilder().BuildAndAddToContext(DataContext);

            SetupBookingForCampaign(expectedCampaign.Id);
            SetupBookingForCampaign(otherCampaign.Id);

            var bookings = await GetCampaignBookings(expectedCampaign.Id);

            Assert.Single(bookings.Items);
        }

        [Fact]
        public async Task ReturnTheCorrectId()
        {
            var campaign = new CampaignBuilder().BuildAndAddToContext(DataContext);
            var (booking, face) = SetupBookingForCampaign(campaign.Id);

            var response = await GetCampaignBookings(campaign.Id);

            var bookingResponse = Assert.Single(response.Items);
            Assert.Equal(face.Id.ToString(), bookingResponse.FaceId);
        }

        private (Booking, Face) SetupBookingForCampaign(Guid campaignId)
        {
            var face = new FaceBuilder().BuildAndAddToContext(DataContext);
            var booking = new Booking() { CampaignId = campaignId, FaceId = face.Id };
            DataContext.Bookings.Add(booking);
            return (booking, face);
        }

        private async Task<ListCampaignBookingsResponse> GetCampaignBookings(Guid campaignId)
        {
            var url = CreateUrl(GetEndpoint(campaignId));
            var response = await Client.GetAsync(url);
            response.AssertSuccessResponse();

            return await Deserialize(response);
        }

        private Task<ListCampaignBookingsResponse> Deserialize(HttpResponseMessage response)
        {
            return response.AssertCollectionResponseType<ListCampaignBookingsResponse, ListCampaignBookingsResponse.BookingResponse>();
        }

        private string GetEndpoint(Guid campaignId)
        {
            return $"campaign/{campaignId}/bookings";
        }
    }
}