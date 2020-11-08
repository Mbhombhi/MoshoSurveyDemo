﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Survey.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class surveyEntities : DbContext
    {
        public surveyEntities()
            : base("name=surveyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAnswer> tblAnswers { get; set; }
        public virtual DbSet<tblQuestion> tblQuestions { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int InsertAnswer(Nullable<int> userId, Nullable<int> questionId, string answer)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var questionIdParameter = questionId.HasValue ?
                new ObjectParameter("questionId", questionId) :
                new ObjectParameter("questionId", typeof(int));
    
            var answerParameter = answer != null ?
                new ObjectParameter("answer", answer) :
                new ObjectParameter("answer", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertAnswer", userIdParameter, questionIdParameter, answerParameter);
        }
    
        public virtual int InsertUser(string surname, string firstname, string contact, Nullable<System.DateTime> dob, Nullable<int> age)
        {
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            var firstnameParameter = firstname != null ?
                new ObjectParameter("firstname", firstname) :
                new ObjectParameter("firstname", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("contact", contact) :
                new ObjectParameter("contact", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUser", surnameParameter, firstnameParameter, contactParameter, dobParameter, ageParameter);
        }
    
        public virtual int Question(string question)
        {
            var questionParameter = question != null ?
                new ObjectParameter("question", question) :
                new ObjectParameter("question", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Question", questionParameter);
        }
    }
}