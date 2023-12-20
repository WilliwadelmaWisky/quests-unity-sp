using System;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public class LevelSystem
    {
        private const int MIN_LEVEL = 0;

        /// <summary>
        /// Level 0 distribution should be 0, otherwise weird behaviour might occur.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public delegate int ExperienceDistribution(int level);


        public event Action OnExperieneChanged;
        public event Action OnLevelChanged;

        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int TargetExperience { get; private set; }

        private readonly ExperienceDistribution _experienceDistribution;
        private readonly int _maxLevel;

        public float ExperienceNormalized => Math.Clamp((float)(Experience - GetExperience(Level)) / (TargetExperience - GetExperience(Level)), 0, 1);
        public float LevelNormalized => Math.Clamp((float)Level / _maxLevel, 0, 1);
        public bool MaxLevel => Level >= _maxLevel;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int LinearDistribution(int level, int a = 100) => a * level;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int SquaredDistribution(int level, int a = 100) => a * level * level;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxLevel"></param>
        /// <param name="experienceDistribution"></param>
        public LevelSystem(int maxLevel, ExperienceDistribution experienceDistribution)
        {
            _maxLevel = maxLevel;
            _experienceDistribution = experienceDistribution;
            Level = MIN_LEVEL;
            Experience = 0;
            TargetExperience = GetExperience(Level + 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public int GetExperience(int level) => Math.Max(0, _experienceDistribution(level));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        protected virtual bool CanLevelUp(int level) => true;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void AddExperience(int amount)
        {
            if (amount <= 0 || MaxLevel)
                return;

            Experience += amount;
            while (Experience >= TargetExperience && !MaxLevel && CanLevelUp(Level + 1))
                LevelUp();

            OnExperieneChanged?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void RemoveExperience(int amount)
        {
            if (amount <= 0 || Experience <= 0)
                return;

            Experience -= Math.Min(amount, Experience);
            while (Experience < GetExperience(Level) && Level > MIN_LEVEL)
                LevelDown();

            OnExperieneChanged?.Invoke();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(int level)
        {
            Level = Math.Clamp(level, MIN_LEVEL, _maxLevel);
            TargetExperience = GetExperience(Level + 1);
            OnLevelChanged?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelUp() => SetLevel(Level + 1);

        /// <summary>
        /// 
        /// </summary>
        public void LevelDown() => SetLevel(Level - 1);
    }
}
