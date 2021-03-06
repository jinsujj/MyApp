﻿using MyApp.Models.DotNetNote;
using System.Collections.Generic;

namespace MyApp.Data.Repositorys.DotNetNote
{
    public interface INoteRepository
    {
        int DeleteNote(int id, string password);
        List<Note> GetAll(int page, string category);
        List<Note> GetCardAll(string category);
        int GetCountAll();
        int GetCountBySearch(string searchField, string searchQuery);
        string GetFileNameById(int id);
        List<Note> GetNewPhotos();
        string GetLatestId(int pageindex,string category);
        Note GetNoteById(int id, bool isDetail);
        List<Note> GetNoteSummaryByCategory(string category);
        List<Note> GetRecentPosts(int numberOfNotes);
        List<Note> GetSearchAll(int page, string searchField, string searchQuery);
        void Pinned(int id);
        void ReplyNote(Note model);
        int SaveOrUpdate(Note n, BoardWriteFormType formType);
        void UpdateDownCount(string fileName);
        void UpdateDownCountById(int id);
        int UpdateNote(Note model);
        void Add(Note note);
        void Log(string page, string ip);
        CategoryList GetCategoryCnt();
    }
}