using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using StudyProject.Application.Common.Interfaces;
using StudyProject.Core.ArticleAggregate;
using StudyProject.Core.Models;
using StudyProject.Infrastructure.DTOs;
using System.Net.Http.Json;

namespace StudyProject.Infrastructure
{
    public class FirebaseContext : IDatabaseContext
	{
        private const string articlesPath = "articles";
        private const string studyGuidesPath = "studyguides";
        private const string exercisePath = "exercises";
		private readonly FirebaseClient firebaseClient;

		public FirebaseContext(FirebaseClient firebaseClient)
		{
			this.firebaseClient = firebaseClient;
		}


        public async Task<Article> GetArticleAsync(string id)
        {
            try
            {
                return await firebaseClient.Child($"{articlesPath}/{id}").OnceSingleAsync<Article>();
            }
            catch
            {
                Console.WriteLine("Couldn't find article with specified ID");
            }

            return Article.NotFound;

        }

        public async Task<string> AddArticleAsync(Article article)
        {
            article.LastEdit = DateTime.Now;
            try
            {
                string id = CreateId(article.Title);
                await firebaseClient.Child(articlesPath).Child(id).PutAsync(article);
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding article: {ex.Message}");
            }
            return string.Empty;
        }

        public async Task<bool> UpdateArticleAsync(string id, Article updatedArticle)
        {
            updatedArticle.LastEdit = DateTime.Now;
            try
            {
                await firebaseClient.Child($"{articlesPath}/{id}").PutAsync(JsonConvert.SerializeObject(updatedArticle));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating article: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteArticleAsync(string id)
        {
            try
            {
                await firebaseClient.Child($"{articlesPath}/{id}").DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting article: {ex.Message}");
                return false;
            }
        }

		public async Task<DateTime> GetArticleLastEditAsync(string id)
		{
			try
			{
				return await firebaseClient.Child($"{articlesPath}/{id}/LastEdit").OnceSingleAsync<DateTime>();
			}
			catch
			{
				Console.WriteLine("Couldn't find article with specified ID");
			}

			return DateTime.Now;

		}

        public string CreateId(string name) => name.Trim().Replace(" ", "-").ToLower();

		public async Task<Article[]> SearchArticlesAsync(string query)
		{
            var response = await firebaseClient.Child(articlesPath)
                .OrderByKey()
                .StartAt(CreateId(query))
                .EndAt(query + "\uf8ff")
                .OnceAsync<Article>();

            var result = response.Select(e => e.Object).ToArray();


            return result;
		}

        public async Task<string[]> GetArticleIdsAsync()
        {
            var response = await firebaseClient.Child(articlesPath)
                .Shallow()
                .OnceAsync<string>();

            return response.Select(e => e.Key).ToArray();
        }

        public async Task<string[]> GetStudyGuideIdsAsync()
        {
            var response = await firebaseClient.Child(studyGuidesPath)
                .Shallow()
                .OnceAsync<string>();

            return response.Select(e => e.Key).ToArray();
        }

        public async Task<StudyGuide> GetStudyGuideAsync(string name)
        {
            var response = await firebaseClient.Child($"{studyGuidesPath}/{name}")
                .OnceSingleAsync<StudyGuide>();

            return response;
        }

        public async Task<string> AddStudyGuideAsync(StudyGuide guide)
        {
            try
            {
                string id = CreateId(guide.Name);
                await firebaseClient.Child(studyGuidesPath)
                    .Child(id)
                    .PutAsync(guide);

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding guide: {ex.Message}");
            }
            return string.Empty;
        }

        public async Task<Exercise> GetExerciseAsync(string id)
        {
            try
            {
                return await firebaseClient.Child($"{exercisePath}/{id}").OnceSingleAsync<Exercise>();
            }
            catch
            {
                Console.WriteLine("Couldn't find exercise with specified ID");
            }

            return Exercise.NotFound;


        }

        public async Task<string> AddExerciseAsync(Exercise exercise)
        {
            try
            {
                string id = exercise.Id;
                await firebaseClient.Child(exercisePath).Child(id).PutAsync(exercise);
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding exercise: {ex.Message}");
            }
            return string.Empty;
        }
    }
}