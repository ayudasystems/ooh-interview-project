using System;
using System.Net.Http;
using System.Threading.Tasks;
using OohInterview.Api.Campaigns.List;
using OohInterview.Api.IntegrationTests.Assertions;
using OohInterview.DAL.Builders;
using Xunit;

namespace OohInterview.Api.IntegrationTests.Tests.Campaigns
{
    public class ListCampaignsShould : BaseIntegrationTest
    {
        private const string Endpoint = "campaigns";

        [Fact]
        public async Task ReturnA200Response()
        {
            var url = CreateUrl(Endpoint);
            var response = await Client.GetAsync(url);
            response.AssertSuccessResponse();
        }

        [Fact]
        public async Task ReturnAllOfTheCampaigns()
        {
            new CampaignBuilder().BuildAndAddToContext(DataContext);
            new CampaignBuilder().BuildAndAddToContext(DataContext);

            var campaigns = await GetCampaigns();

            Assert.Equal(2, campaigns.Items.Count);
        }

        [Fact]
        public async Task ReturnTheCorrectId()
        {
            var id = Guid.NewGuid();
            new CampaignBuilder()
                .WithId(id)
                .BuildAndAddToContext(DataContext);

            var response = await GetCampaigns();

            var campaign = Assert.Single(response.Items);
            Assert.Equal(id.ToString(), campaign.Id);
        }

        [Fact]
        public async Task ReturnTheCorrectName()
        {
            const string name = "A Test Campaign Name";
            new CampaignBuilder()
                .WithName(name)
                .BuildAndAddToContext(DataContext);

            var response = await GetCampaigns();

            var campaign = Assert.Single(response.Items);
            Assert.Equal(name, campaign.Name);
        }

        [Fact]
        public async Task ReturnTheCorrectStartDate()
        {
            var startDate = new DateTime(2019, 05, 23);
            new CampaignBuilder()
                .WithStartDate(startDate)
                .BuildAndAddToContext(DataContext);

            var response = await GetCampaigns();

            var campaign = Assert.Single(response.Items);
            Assert.Equal(startDate, campaign.StartDate);
        }

        [Fact]
        public async Task ReturnTheCorrectEndDate()
        {
            var endDate = new DateTime(2022, 06, 23);
            new CampaignBuilder()
                .WithEndDate(endDate)
                .BuildAndAddToContext(DataContext);

            var response = await GetCampaigns();

            var campaign = Assert.Single(response.Items);
            Assert.Equal(endDate, campaign.EndDate);
        }

        private async Task<ListCampaignsResponse> GetCampaigns()
        {
            var response = await Client.GetAsync(CreateUrl(Endpoint));
            response.AssertSuccessResponse();

            return await Deserialize(response);
        }

        private Task<ListCampaignsResponse> Deserialize(HttpResponseMessage response)
        {
            return response.AssertCollectionResponseType<ListCampaignsResponse, ListCampaignsResponse.CampaignResponse>();
        }
    }
}