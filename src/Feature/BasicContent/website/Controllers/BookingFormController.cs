using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Mvc.Presentation;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using SMEProject.Feature.BasicContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMEProject.Feature.BasicContent.Controllers
{
    public class BookingFormController : Controller
    {
        // GET: BookingData
        [HttpGet]
        public ActionResult BookingForm()
        {
            var BookingForm = RenderingContext.Current.Rendering.Item;
            BookingFormLabelModel bookingFormLabelModel = new BookingFormLabelModel()
            {
                NameLabel = BookingForm.Fields["NameLabel"].Value,
                EmailLabel = BookingForm.Fields["EmailLabel"].Value,
                AddressLabel = BookingForm.Fields["AddressLabel"].Value,
                BookingDateLabel = BookingForm.Fields["BookingDateLabel"].Value,
                PhoneNumberLabel = BookingForm.Fields["PhoneNumberLabel"].Value,
                VacatingDateLabel = BookingForm.Fields["VacatingDateLabel"].Value,
                SubmitButtonLabel = BookingForm.Fields["SubmitButtonLabel"].Value,
                PhoneNumberPlaceholder = BookingForm.Fields["PhoneNumberPlaceholder"].Value,
                AddressPlaceholder = BookingForm.Fields["AddressPlaceholder"].Value,
                EmailPlaceholder = BookingForm.Fields["EmailPlaceholder"].Value,
                NamePlaceholder = BookingForm.Fields["NamePlaceholder"].Value,
                BookingDatePlaceholder = BookingForm.Fields["BookingDatePlaceholder"].Value,
                VacatingDatePlaceholder = BookingForm.Fields["VacatingDatePlaceholder"].Value,
            };

            BookingFormModel bookingFormModel = new BookingFormModel()
            {
                Name = "Name",
                Email = "Email",
                PhoneNumber = "PhoneNumber",
                Address = "Address",
                BookingDate = "BookingDate",
                VacatingDate = "VacatingDate",
            };

            BookingFormViewModel bookingFormViewModel = new BookingFormViewModel()
            {
                BookingFormModel = bookingFormModel,
                BookingFormLabelModel = bookingFormLabelModel
            };
            return View("/Views/SMEProject/BasicContent/BookingForm.cshtml",bookingFormViewModel);
        }

        [HttpPost]
        public ActionResult BookingForm(BookingFormModel input)
        {
            BookingFormModel bookingFormModel = new BookingFormModel()
            {
                Name = input.Name,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                BookingDate = input.BookingDate,
                VacatingDate = input.VacatingDate
            };
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDatabase = Sitecore.Configuration.Factory.GetDatabase("web");
            var parentItem = Sitecore.Context.Item;
            var parentItemFromMaster = masterDatabase.GetItem(parentItem.ID);
            var templateId = new TemplateID(new ID("{E238C9C7-DF3D-49C3-8F27-552467B8B71F}"));
          
            using (new SecurityDisabler())
            {
                var newBooking = parentItemFromMaster.Add(input.Name, templateId);
                newBooking.Editing.BeginEdit();
                newBooking.Fields["Name"].Value = input.Name;
                newBooking.Fields["Email"].Value = input.Email;
                newBooking.Fields["PhoneNumber"].Value = input.PhoneNumber;
                newBooking.Fields["Address"].Value = input.Address;
                newBooking.Fields["BookingDate"].Value = input.BookingDate;
                newBooking.Fields["VacatingDate"].Value = input.VacatingDate;
                newBooking.Editing.EndEdit();
                
                Language language = Sitecore.Context.Language;

                PublishOptions publishOptions = new PublishOptions(masterDatabase, webDatabase, PublishMode.SingleItem, language, DateTime.Now);
                publishOptions.Deep = true;
                publishOptions.RootItem = newBooking;
                Publisher publisher = new Publisher(publishOptions);
                publisher.Publish();
            }
           
            return View("/Views/SMEProject/BasicContent/BookingConfirmation.cshtml", bookingFormModel);
        }
    }
}