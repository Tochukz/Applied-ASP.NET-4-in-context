using System;
using System.Collections.Generic;
using System.Linq;


namespace DataApp
{
    public static class DataAccess
    {
        public static string[] GetEventTypeNames(TrainingDataEntities entityContext)
        {
            return entityContext.EventTypes.Select(e => e.Name).ToArray();
        }

        public static string[] GetAthleteNames(TrainingDataEntities entityContext)
        {
            return entityContext.Athletes.Select(a => a.Name).ToArray();
        }

        public static RankingSet GetReferenceRanking(TrainingDataEntities entityContext, Event eventParam)
        {
            return new RankingSet(entityContext.GetReferenceRanking1(eventParam.Type, eventParam.SwimTime, eventParam.CycleTime, eventParam.RunTime, eventParam.OverallTime));
        }

        public static RankingSet GetPersonalRanking(TrainingDataEntities entityContext, Event eventParam)
        {
            return new RankingSet(entityContext.GetPersonalRanking1(eventParam.Athlete, eventParam.Type, eventParam.SwimTime, eventParam.CycleTime, eventParam.RunTime, eventParam.OverallTime));
        }

        public static IEnumerable<Event> GetAllEvents(TrainingDataEntities entityContext)
        {
            return entityContext.Events;
        }

        public static IEnumerable<Event> GetEventsByType(TrainingDataEntities entityContext, string typeParam)
        {
            return entityContext.Events.Where(e => e.Type == typeParam).Select(e => e);
        }

        public static void AddEvent(TrainingDataEntities entityContext, DateTime timeParam, string athleteParam, string typeParam, TimeSpan swimTimeParam, TimeSpan cycleTimeParam, TimeSpan runTimeParam)
        {
            Event newEvent = new Event()
            {
                Date = timeParam,
                Athlete = athleteParam,
                Type = typeParam,
                SwimTime = swimTimeParam,
                CycleTime = cycleTimeParam,
                RunTime = runTimeParam,
                OverallTime = swimTimeParam + cycleTimeParam + runTimeParam
            };

            entityContext.Events.Add(newEvent);
            try
            {
                entityContext.SaveChanges();
            }
            catch(InvalidOperationException ex)
            {
                //ex.Message;
                throw ex;
            }
            catch(Exception ex)
            {
                // ex.InnerException.Message;
                throw ex;
            }
        } 

        public static void UpdateEvent(TrainingDataEntities entityContext, int keyParam, DateTime dateParam, string athleteParam, string typeParam, TimeSpan swimTimeParam, TimeSpan cycleTimeParam, TimeSpan runTimeParam)
        {
            // query for the event with the specified key
            Event targetEvent = GetEventByID(entityContext, keyParam);

            // set the param valuesfor the event
            if (targetEvent != null)
            {
                // update the event object properties
                targetEvent.Date = dateParam;
                targetEvent.Athlete = athleteParam;
                targetEvent.Type = typeParam;
                targetEvent.SwimTime = swimTimeParam;
                targetEvent.CycleTime = cycleTimeParam;
                targetEvent.RunTime = runTimeParam;
                targetEvent.OverallTime = swimTimeParam + cycleTimeParam + runTimeParam;

                entityContext.SaveChanges();
            }
        }

        public static Event GetEventByID(TrainingDataEntities entityContext, int keyParam)
        {
            // query for the ID
            IEnumerable<Event> results = entityContext.Events.Where(e => e.ID == keyParam).Select(e => e);

            // as the ID is primary key, there will be zero or on results
            return results.Count() == 1 ? results.First() : null;
        }

        public static void DeleteEventByID(TrainingDataEntities entityContext, int keyParam)
        {
            // query for the object that has the specified key
            Event targetEvent = GetEventByID(entityContext, keyParam);

            if (targetEvent != null)
            {
                entityContext.Events.Remove(targetEvent);
                entityContext.SaveChanges();
            }
        }
    }
}