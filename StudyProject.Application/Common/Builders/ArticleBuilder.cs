﻿using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.ArticleAggregate.Interfaces;
using StudyProject.Core.Models;

namespace StudyProject.Application.Common.Builders
{

    /// <summary>
    /// Represents a builder for creating articles.
    /// </summary>
    public class ArticleBuilder : IArticleBuilder
    {
        private readonly Article article = new();

        /// <inheritdoc/>
        public Article Build()
        {
            return article;
        }


        /// <inheritdoc/>
        public IArticleBuilder WithContent(string content)
        {
            article.Content = content;
            return this;
        }

        /// <inheritdoc/>
        public IArticleBuilder WithDisciplines(Discipline[] disciplines)
        {
            article.Disciplines = disciplines;
            return this;
        }

        public IArticleBuilder WithId(HexId id)
        {
            article.Id = id;
            return this;
        }

        public IArticleBuilder WithId(string id)
        {
            article.Id = new HexId(id);
            return this;
        }

        /// <inheritdoc/>
        public IArticleBuilder WithSubjects(Subject[] subjects)
        {
            article.Subjects = subjects;
            return this;
        }

        /// <inheritdoc/>
        public IArticleBuilder WithTitle(string title)
        {
            article.Title = title;
            return this;
        }

        /// <inheritdoc/>
        public IArticleBuilder WithTopics(Topic[] topics)
        {
            article.Topics = topics;
            return this;
        }
    }
}