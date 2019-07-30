using Our.Umbraco.Look.AzureSearch.Services;
using System;
using System.ComponentModel;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Our.Umbraco.Look
{
    /// <summary>
    /// Umbraco start-up event to initialize Look for Azure Search
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // hide from api intellisense
    public class UmbracoStartUp : ApplicationEventHandler
    {
        /// <summary>
        /// shared umbraco helper
        /// </summary>
        private UmbracoHelper _umbracoHelper;

        /// <summary>
        /// Umbraco started
        /// </summary>
        /// <param name="umbracoApplication"></param>
        /// <param name="applicationContext"></param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            this._umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            LookService.Initialize(this._umbracoHelper);

            // TODO: only wire up if there are azure indexes

            ContentService.Published += this.ContentService_Published;
            MediaService.Saved += this.MediaService_Saved;
            MemberService.Saved += this.MemberService_Saved;

            ContentService.UnPublished += this.ContentService_UnPublished;
            MediaService.Deleted += this.MediaService_Deleted;
            MemberService.Deleted += this.MemberService_Deleted;
        }

        private void ContentService_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            this.Update(
                    e.PublishedEntities.Select(x => this._umbracoHelper.TypedContent(x.Id)).ToArray(),
                    PublishedItemType.Content);
        }

        private void MediaService_Saved(IMediaService sender, SaveEventArgs<IMedia> e)
        {
            this.Update(
                    e.SavedEntities.Select(x => this._umbracoHelper.TypedMedia(x.Id)).ToArray(),
                    PublishedItemType.Media);
        }

        private void MemberService_Saved(IMemberService sender, SaveEventArgs<IMember> e)
        {
            this.Update(
                    e.SavedEntities.Select(x => this._umbracoHelper.TypedMember(x.Id)).ToArray(),
                    PublishedItemType.Member);
        }

        private void ContentService_UnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            this.Remove(e.PublishedEntities.Select(x => x.Id).ToArray());
        }

        private void MediaService_Deleted(IMediaService sender, DeleteEventArgs<IMedia> e)
        {
            this.Remove(e.DeletedEntities.Select(x => x.Id).ToArray());
        }

        private void MemberService_Deleted(IMemberService sender, DeleteEventArgs<IMember> e)
        {
            this.Remove(e.DeletedEntities.Select(x => x.Id).ToArray());
        }


        /// <summary>
        /// Update the Lucene document in all indexes
        /// </summary>
        /// <param name="publishedContentItems"></param>
        /// <param name="publishedItemType"></param>
        private void Update(IPublishedContent[] publishedContentItems, PublishedItemType publishedItemType)
        {
            if (publishedContentItems == null || !publishedContentItems.Any()) return;

            // for each index, for each item
            //  call remove
            //  build context
            //  call service to index

            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="ids">The Umbraco Content, Media or Member Ids (Detached items do not have Ids)</param>
        private void Remove(int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
